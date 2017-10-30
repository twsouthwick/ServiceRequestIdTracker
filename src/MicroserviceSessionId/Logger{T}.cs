// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using System;

namespace MicroserviceSessionId
{
    internal class Logger<T> : ILogger<T>
    {
        private readonly IMicroserviceSessionIdAccessor _accessor;
        private readonly ILogger _other;

        public Logger(ILoggerFactory factory, IMicroserviceSessionIdAccessor accessor)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _accessor = accessor;
            _other = new Microsoft.Extensions.Logging.Logger<T>(factory);
        }

        public IDisposable BeginScope<TState>(TState state) => _other.BeginScope(state);

        public bool IsEnabled(LogLevel logLevel) => _other.IsEnabled(logLevel);

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var id = _accessor.Id;

            if (id != null)
            {
                using (_other.BeginScope("{MicroServiceRequestId}", id))
                {
                    _other.Log(logLevel, eventId, state, exception, formatter);
                }
            }
            else
            {
                _other.Log(logLevel, eventId, state, exception, formatter);
            }
        }
    }
}
