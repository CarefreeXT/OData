// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Exceptions
{
    using System;
    using Res = Properties.Resources;
    /// <summary>
    /// 类型找不到主键异常。
    /// </summary>
    public class TypeNotFoundKeyException : Exception
    {
        /// <summary>
        /// 创建异常。
        /// </summary>
        /// <param name="type">指定的CLR类型。</param>
        public TypeNotFoundKeyException(Type type)
            : base(string.Format(Res.Exception_TypeNotFoundKey, type))
        {
            ClrType = type;
        }
        /// <summary>
        /// 指定的CLR类型。
        /// </summary>
        public Type ClrType { get; }
    }
}
