// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core
{
    using System;
    using System.Reflection;

    internal class DefalutClrTypeKeyResolver : IClrTypeKeyResolver
    {
        public PropertyInfo[] ResolveKeys(Type clrType, PropertyInfo[] members)
        {
            return null;
        }
    }
}
