using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

using static MicroserviceSessionId.Constants;

namespace MicroserviceSessionId
{
    public class MicroserviceSessionIdException : Exception
    {
        private readonly StringValues _values;

        internal MicroserviceSessionIdException(StringValues values)
        {
            _values = values;
        }

        public IReadOnlyCollection<string> Headers => _values;

        public override string Message => $"Error: Contains '{_values.Count}' instances of '{SessionId}' header: '{_values}'";
    }
}
