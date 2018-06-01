// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System;
    /// <summary>
    /// 控制器方法枚举。
    /// </summary>
    internal enum EControllerMethodKind
    {

        /// <summary>
        /// 方法模板：GET ~/entityset/key
        /// 声明示例：Get(int key)
        ///  URL示例：http://localhost/odata/Customers(1)
        /// </summary>
        GetItem,
        /// <summary>
        /// 方法模板：GET ~/entityset
        /// 声明示例：Get()
        ///  URL示例：http://localhost/odata/Customers
        /// </summary>
        GetItems,
        /// <summary>
        /// 方法模板：POST ~/entityset
        /// 声明示例：Post([FromBody]Customer[] customer)
        ///  URL示例：http://localhost/odata/Customers
        /// </summary>
        PostItems,
        /// <summary>
        /// 方法模板：PUT/PATCH ~/entityset/key
        /// 声明示例：Put(int key, [FromBody]Customer customer)
        ///  URL示例：http://localhost/odata/Customers(1)
        /// </summary>
        PutItem,
        /// <summary>
        /// 方法模板：PUT/PATCH ~/entityset
        /// 声明示例：Put([FromBody]Customer[] customers)
        ///  URL示例：http://localhost/odata/Customers
        /// </summary>
        PutItems,
        /// <summary>
        /// 方法模板：DELETE ~/entityset/key
        /// 声明示例：Delete(int key)
        ///  URL示例：http://localhost/odata/Customers(1)
        /// </summary>
        DeleteItem,
        /// <summary>
        /// 方法模板：DELETE ~/entityset
        /// 声明示例：Delete([FromBody]Customer[] customers)
        ///  URL示例：http://localhost/odata/Customers
        /// </summary>
        DeleteItems,
        /// <summary>
        /// 方法模板：GET ~/entityset/key/navigate
        /// 声明示例：GetOrders(int key)
        ///  URL示例：http://localhost/odata/Customers(1)/Orders
        /// </summary>
        Navigate,
        /// <summary>
        /// 方法模板：POST ~/entityset/Action()
        /// 声明示例：Action(int para1)
        ///  URL示例：http://localhost/odata/Customers/Action()
        /// </summary>
        BoundAction,
        /// <summary>
        /// 方法模板：POST ~/entityset/key/Action()
        /// 声明示例：Action(int key, int para1)
        ///  URL示例：http://localhost/odata/Customers(1)/Action()
        /// </summary>
        UnboundAction,
        /// <summary>
        /// 方法模板：GET ~/entityset/function(paras)
        /// 声明示例：Function(int para1, object para2)
        ///  URL示例：http://localhost/odata/Customers/Function(1,@para2)
        /// </summary>
        BoundFunction,
        /// <summary>
        /// 方法模板：GET ~/entityset/key/function(paras)
        /// 声明示例：Function(int key, int para1, object para2)
        ///  URL示例：http://localhost/odata/Customers(1)/Function(1,@para2)
        /// </summary>
        UnboundFunction,
        /// <summary>
        /// 方法模板：POST/PUT ~/entityset/key/navigate/$ref?$id=entityset/key
        /// 声明示例：CreateRef(int key, string navigateProperty, string link)
        ///  URL示例：http://localhost/odata/Customers(1)/Orders/$ref?$id=Orders(1)
        /// </summary>
        CreateRef,
        /// <summary>
        /// 方法模板：POST/PUT ~/entityset/navigate/$ref
        /// 声明示例：CreateRef(string navigateProperty, [FromBody]object[] pairs)
        ///  URL示例：http://localhost/odata/Customers/Orders/$ref
        /// </summary>
        CreateRefBatch,
        /// <summary>
        /// 方法模板：DELETE ~/entityset/key/navigate/$ref?$id=entityset/key
        /// 声明示例：DeleteRef(int key, string navigateProperty, string link)
        ///  URL示例：http://localhost/odata/Customers(1)/Orders/$ref?$id=Orders(1)
        /// </summary>
        DeleteRef,
        /// <summary>
        /// 方法模板：DELETE ~/entityset/key/navigate/$ref
        /// 声明示例：DeleteRef(int key, string navigateProperty)
        ///  URL示例：http://localhost/odata/Customers(1)/Orders/$ref
        /// </summary>
        DeleteRefObject,
        /// <summary>
        /// 方法模板：DELETE ~/entityset/navigate/$ref
        /// 声明示例：DeleteRef(string navigateProperty, [FromBody]object[] pairs)
        ///  URL示例：http://localhost/odata/Customers/Orders/$ref
        /// </summary>
        DeleteRefBatch,
    }
}
