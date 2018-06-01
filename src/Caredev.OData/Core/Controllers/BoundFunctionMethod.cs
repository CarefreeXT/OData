// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System.Reflection;
    /// <summary>
    /// 绑定到集合的Function方法。
    /// </summary>
    internal class BoundFunctionMethod : IControllerMethod
    {
        /// <summary>
        /// 创建绑定到集合的Function方法。
        /// </summary>
        /// <param name="method">反射的方法。</param>
        /// <param name="para">Function参数名集合。</param>
        public BoundFunctionMethod(MethodInfo method, params string[] para)
        {
            Method = method;
            Parameters = para;
        }
        /// <summary>
        /// Function参数名集合。
        /// </summary>
        public string[] Parameters { get; }
        /// <summary>
        /// 反射的方法。
        /// </summary>
        public MethodInfo Method { get; }
    }
}