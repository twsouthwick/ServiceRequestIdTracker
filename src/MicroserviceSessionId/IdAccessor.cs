// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading;

namespace MicroserviceSessionId
{
    internal class IdAccessor : IMicroserviceSessionIdAccessor
    {
        private static readonly AsyncLocal<string> _id = new AsyncLocal<string>();

        public string Id
        {
            get { return _id.Value; }
            set { _id.Value = value; }
        }
    }
}
