﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using System;

namespace MicroserviceSessionId
{
    internal class Logger<T> : ILogger<T>
    {
        private readonly IMicroserverSessionIdAccessor _accessor;
        private readonly ILogger _other;

        public Logger(ILoggerFactory factory, IMicroserverSessionIdAccessor accessor)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _accessor = accessor;
            _other = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            var scope = _other.BeginScope(state);

            return new CombinedScope(scope, SetId());
        }

        public bool IsEnabled(LogLevel logLevel) => _other.IsEnabled(logLevel);

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            using (SetId())
            {
                _other.Log(logLevel, eventId, state, exception, formatter);
            }
        }

        private IDisposable SetId()
        {
            var id = _accessor.Id;

            if (id != null)
            {
                return _other.BeginScope("{MicroServiceRequestId}", id);
            }
            else
            {
                return EmptyDisposable.Instance;
            }
        }

        private class CombinedScope : IDisposable
        {
            private readonly IDisposable _disposable1;
            private readonly IDisposable _disposable2;

            public CombinedScope(IDisposable disposable1, IDisposable disposable2)
            {
                _disposable1 = disposable1;
                _disposable2 = disposable2;
            }

            public void Dispose()
            {
                _disposable1.Dispose();
                _disposable2.Dispose();
            }
        }

        private class EmptyDisposable : IDisposable
        {
            public static IDisposable Instance { get; } = new EmptyDisposable();

            private EmptyDisposable()
            {
            }

            public void Dispose()
            {
            }
        }
    }
}
