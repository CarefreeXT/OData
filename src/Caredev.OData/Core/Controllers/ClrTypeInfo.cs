// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using Caredev.OData.Core.Exceptions;
    using Caredev.OData.Core.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    /// <summary>
    /// 数据对象CLR类型信息。
    /// </summary>
    internal class ClrTypeInfo
    {
        /// <summary>
        /// 创建数据对象CLR类型信息。
        /// </summary>
        /// <param name="clrType">CLR类型对象。</param>
        /// <param name="resolver">数据对象的主键查找对象。</param>
        public ClrTypeInfo(Type clrType, IClrTypeKeyResolver resolver)
        {
            ClrType = clrType;
            Navigates = clrType.GetProperties()
                .Where(a => a.PropertyType.IsComplex())
                .ToDictionary(a => a.Name, a => a);
            var valueMembers = clrType.GetProperties().Where(a => !a.PropertyType.IsComplex()).ToArray();
            Keys = resolver.ResolveKeys(clrType, valueMembers);
            if (Keys == null || Keys.Length == 0)
            {
                var name = clrType.Name + Constants.KeyNameSuffix;
                Keys = valueMembers.Where(a => a.Name == name).ToArray();
                if (Keys.Length == 0)
                {
                    Keys = valueMembers.Where(a => a.Name == Constants.KeyNameSuffix).ToArray();
                }
            }
            if (Keys.Length == 0)
            {
                throw new TypeNotFoundKeyException(clrType);
            }
        }
        /// <summary>
        /// CLR类型对象。
        /// </summary>
        public Type ClrType { get; }
        /// <summary>
        /// 主键集合。
        /// </summary>
        public PropertyInfo[] Keys { get; }
        /// <summary>
        /// 导航成员集合。
        /// </summary>
        public Dictionary<string, PropertyInfo> Navigates { get; }
    }
}