// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System.Reflection;
    /// <summary>
    /// 关联到数据对象的Function方法。
    /// </summary>
    internal class UnboundFunctionMethod : IControllerMethod
    {
        /// <summary>
        /// 创建关联到数据对象的Function方法。
        /// </summary>
        /// <param name="method">反射的方法。</param>
        /// <param name="keys">数据对象主键参数名集合。</param>
        /// <param name="paras">Function参数名集合。</param>
        public UnboundFunctionMethod(MethodInfo method, string[] keys, params string[] paras)
        {
            Method = method;
            Keys = keys;
            Parameters = paras;
        }
        /// <summary>
        /// 数据对象主键参数名集合。
        /// </summary>
        public string[] Keys { get; }
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