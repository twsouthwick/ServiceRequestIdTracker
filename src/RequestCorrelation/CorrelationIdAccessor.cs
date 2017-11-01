// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;

namespace RequestCorrelation
{
    internal class CorrelationIdAccessor : ICorrelationIdAccessor
    {
        public string Id { get; set; }
    }
}
