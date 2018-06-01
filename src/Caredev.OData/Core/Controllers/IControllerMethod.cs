// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System.Reflection;
    /// <summary>
    /// 控制器方法接口。
    /// </summary>
    internal interface IControllerMethod
    {
        /// <summary>
        /// 反射的方法。
        /// </summary>
        MethodInfo Method { get; }
    }
}