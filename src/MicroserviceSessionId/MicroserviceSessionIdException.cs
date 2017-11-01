// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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

        public override string Message => $"Error: Contains '{_values.Count}' instances of '{CorrelationIdHeader}' header: '{_values}'";
    }
}
