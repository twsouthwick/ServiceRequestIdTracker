// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

using static RequestCorrelation.Constants;

namespace RequestCorrelation
{
    public class RequestCorrelationException : Exception
    {
        private readonly StringValues _values;

        internal RequestCorrelationException(StringValues values)
        {
            _values = values;
        }

        public IReadOnlyCollection<string> Headers => _values;

        public override string Message => $"Error: Contains '{_values.Count}' instances of '{CorrelationIdHeader}' header: '{_values}'";
    }
}
