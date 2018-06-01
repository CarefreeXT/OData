// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System.Reflection;
    /// <summary>
    /// 绑定到集合的方法。
    /// </summary>
    internal class BoundMethod : IControllerMethod
    {
        /// <summary>
        /// 创建绑定到集合的方法。
        /// </summary>
        /// <param name="method">反射的方法。</param>
        public BoundMethod(MethodInfo method)
        {
            Method = method;
        }
        /// <summary>
        /// 反射的方法。
        /// </summary>
        public MethodInfo Method { get; }
    }
}