// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData
{
    using System;
#if NETSTANDARD2_0
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
#else
    using System.Web.Http;
    using System.Web.Http.Controllers;
#endif
    /// <summary>
    /// 系统中使用的常量。
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// 路由模板中控制器名称。
        /// </summary>
        public const string ControllerName = "controller";
        /// <summary>
        /// 路由模板中Action名称。
        /// </summary>
        public const string ActionName = "action";
        /// <summary>
        /// 路由模板中OData路径名称。
        /// </summary>
        public const string ODataPath = "odataPath";
        /// <summary>
        /// OData路由模板.
        /// </summary>
        public const string ODataRouteTemplate = "{*" + ODataPath + "}";
        /// <summary>
        /// 控制器GET方法名称。
        /// </summary>
        public const string ActionPrefixGet = "Get";
        /// <summary>
        /// 控制器POST方法名称。
        /// </summary>
        public const string ActionPrefixPost = "Post";
        /// <summary>
        /// 控制器PUT方法名称。
        /// </summary>
        public const string ActionPrefixPut = "Put";
        /// <summary>
        /// 控制器DELETE方法名称。
        /// </summary>
        public const string ActionPrefixDelete = "Delete";
        /// <summary>
        /// 控制器创建关系方法名称。
        /// </summary>
        public const string ActionCreateRef = "CreateRef";
        /// <summary>
        /// 控制器删除关系方法名称。
        /// </summary>
        public const string ActionDeleteRef = "DeleteRef";
        /// <summary>
        /// 控制器中未绑定方法默认主键参数名称。
        /// </summary>
        public const string KeyParameterName = "key";
        /// <summary>
        /// 数据对象主键属性后缀。
        /// </summary>
        public const string KeyNameSuffix = "Id";
        /// <summary>
        /// 从OData Uri加载参数特性。
        /// </summary>
        public readonly static Type FromODataUri = typeof(FromODataUriAttribute);
        /// <summary>
        /// 从请求体加载参数特性。
        /// </summary>
        public readonly static Type FromBody = typeof(FromBodyAttribute);
        /// <summary>
        /// GETT方法特性。
        /// </summary>
        public readonly static Type HttpGet = typeof(HttpGetAttribute);
        /// <summary>
        /// POST方法特性。
        /// </summary>
        public readonly static Type HttpPost = typeof(HttpPostAttribute);
    }
}
