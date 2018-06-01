// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core
{
    using System;
    using System.Reflection;
    /// <summary>
    /// CLR类型检索主键属性方法。
    /// </summary>
    public interface IClrTypeKeyResolver
    {
        /// <summary>
        /// 检索主键。
        /// </summary>
        /// <param name="clrType"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        PropertyInfo[] ResolveKeys(Type clrType, PropertyInfo[] members);
    }
}
