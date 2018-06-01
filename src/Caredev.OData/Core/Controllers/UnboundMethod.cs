// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System.Reflection;
    /// <summary>
    /// 关联到数据对象的方法。
    /// </summary>
    internal class UnboundMethod : IControllerMethod
    {
        /// <summary>
        /// 创建关联到数据对象的方法。
        /// </summary>
        /// <param name="method">反射的方法。</param>
        /// <param name="keys">数据对象主键参数名集合。</param>
        public UnboundMethod(MethodInfo method, string[] keys)
        {
            Method = method;
            Keys = keys;
        }
        /// <summary>
        /// 数据对象主键参数名集合。
        /// </summary>
        public string[] Keys { get; }
        /// <summary>
        /// 反射的方法。
        /// </summary>
        public MethodInfo Method { get; }
    }
}