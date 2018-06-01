// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Extensions
{
    using System;
    internal static class TypeExtensions
    {
        /// <summary>
        /// 判断指定类型是否可以为空。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            if (type.IsClass)
            {
                return true;
            }
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        /// <summary>
        /// 判断指定类型是否为复杂对象类型。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsComplex(this Type type)
        {
            return !type.IsValueType && type != typeof(string);
        }
    }
}
