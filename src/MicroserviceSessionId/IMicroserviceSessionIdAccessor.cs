// Copyright (c) Taylor Southwick. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace MicroserviceSessionId
{
    public interface IMicroserviceSessionIdAccessor
    {
        string Id { get; }
    }
}
