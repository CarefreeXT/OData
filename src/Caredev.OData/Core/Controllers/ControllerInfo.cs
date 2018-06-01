// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
namespace Caredev.OData.Core.Controllers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using Caredev.OData.Core.Extensions;
#if NETSTANDARD2_0
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
#else
    using System.Web.Http;
    using System.Web.Http.Controllers;
#endif
    /// <summary>
    /// 控制器信息体。
    /// </summary>
    internal class ControllerInfo
    {
        /// <summary>
        /// 创建控制器信息体。
        /// </summary>
        /// <param name="clrtype">数据对象CLR类型信息。</param>
        /// <param name="controller">控制器类型。</param>
        /// <param name="name">控制器名称。</param>
        public ControllerInfo(ClrTypeInfo clrtype, Type controller, string name)
        {
            Methods = new Dictionary<EControllerMethodKind, IControllerMethod>();
            Navigates = new Dictionary<string, UnboundMethod>();
            BoundActions = new Dictionary<string, BoundMethod>();
            UnboundActions = new Dictionary<string, UnboundMethod>();
            BoundFunctions = new Dictionary<string, BoundFunctionMethod>();
            UnboundFunctions = new Dictionary<string, UnboundFunctionMethod>();
            Name = name;
            Initialization(clrtype, controller);
        }
        /// <summary>
        /// 控制器名称。
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 按指定控制器方法种类获取相信方法信息对象。
        /// </summary>
        /// <typeparam name="T">方法信息对象类型。</typeparam>
        /// <param name="kind">控制器方法种类。</param>
        /// <param name="key">获取方法的键值。</param>
        /// <returns></returns>
        public T GetAction<T>(EControllerMethodKind kind, string key = "")
            where T : class, IControllerMethod
        {
            switch (kind)
            {
                case EControllerMethodKind.BoundAction:
                    if (BoundActions.TryGetValue(key, out BoundMethod methodAction))
                    {
                        return methodAction as T;
                    }
                    break;
                case EControllerMethodKind.UnboundAction:
                    if (UnboundActions.TryGetValue(key, out UnboundMethod methodActionKeys))
                    {
                        return methodActionKeys as T;
                    }
                    break;
                case EControllerMethodKind.BoundFunction:
                    if (BoundFunctions.TryGetValue(key, out BoundFunctionMethod methodFunction))
                    {
                        return methodFunction as T;
                    }
                    break;
                case EControllerMethodKind.UnboundFunction:
                    if (UnboundFunctions.TryGetValue(key, out UnboundFunctionMethod methodFunctionKeys))
                    {
                        return methodFunctionKeys as T;
                    }
                    break;
                case EControllerMethodKind.Navigate:
                    if (Navigates.TryGetValue(key, out UnboundMethod methodNavi))
                    {
                        return methodNavi as T;
                    }
                    break;
                default:
                    if (Methods.TryGetValue(kind, out IControllerMethod methodSimple))
                    {
                        return methodSimple as T;
                    }
                    break;
            }
            return null;
        }

        private readonly Dictionary<EControllerMethodKind, IControllerMethod> Methods;
        private readonly Dictionary<string, UnboundMethod> Navigates;
        private readonly Dictionary<string, BoundMethod> BoundActions;
        private readonly Dictionary<string, UnboundMethod> UnboundActions;
        private readonly Dictionary<string, BoundFunctionMethod> BoundFunctions;
        private readonly Dictionary<string, UnboundFunctionMethod> UnboundFunctions;

        private void Initialization(ClrTypeInfo type, Type controllerType)
        {
            var methods = controllerType.GetMethods();
            foreach (var method in methods)
            {
                var name = method.Name;
                var paras = method.GetParameters();
                if (name == Constants.ActionCreateRef || name == Constants.ActionDeleteRef)
                {
                    if (ProcessRefMethod(type, method))
                    {
                        continue;
                    }
                }
                else if (name == Constants.ActionPrefixGet || name == Constants.ActionPrefixGet + Name)
                {
                    if (paras.Length == 0)
                    {
                        Methods.AddOrUpdate(EControllerMethodKind.GetItems, new BoundMethod(method));
                        continue;
                    }
                    if (ProcessKeysMethod(type, method, EControllerMethodKind.GetItem))
                    {
                        continue;
                    }
                }
                else if (name == Constants.ActionPrefixPost || name == Constants.ActionPrefixPost + Name)
                {
                    if (ProcessBodyMethod(type, method, EControllerMethodKind.PostItems))
                    {
                        continue;
                    }
                }
                else if (name == Constants.ActionPrefixPut || name == Constants.ActionPrefixPut + Name)
                {
                    if (ProcessBodyMethod(type, method, EControllerMethodKind.PutItems)
                        || ProcessKeysBodyMethod(type, method, EControllerMethodKind.PutItem))
                    {
                        continue;
                    }
                }
                else if (name == Constants.ActionPrefixDelete || name == Constants.ActionPrefixDelete + Name)
                {
                    if (ProcessBodyMethod(type, method, EControllerMethodKind.DeleteItems)
                        || ProcessKeysMethod(type, method, EControllerMethodKind.DeleteItem))
                    {
                        continue;
                    }
                }
                else if (name.StartsWith("Get"))
                {
                    var subname = name.Substring(3);
                    if (type.Navigates.ContainsKey(subname))
                    {
                        var keys = CheckKeyParameters(type, paras);
                        if (keys != null && keys.Length == paras.Length)
                        {
                            Navigates.AddOrUpdate(subname, new UnboundMethod(method, keys));
                            continue;
                        }
                    }
                }

                if (method.IsDefined(Constants.HttpGet))
                {
                    var keys = CheckKeyParameters(type, paras);
                    if (keys != null)
                    {
                        var names = new string[paras.Length - keys.Length];
                        for (int i = 0; i < names.Length; i++)
                        {
                            names[i] = paras[keys.Length + i].Name;
                        }
                        UnboundFunctions.AddOrUpdate(method.Name, new UnboundFunctionMethod(method, keys));
                    }
                    else
                    {
                        BoundFunctions.AddOrUpdate(method.Name, new BoundFunctionMethod(method, paras.Select(a => a.Name).ToArray()));
                    }
                }
                else if (method.IsDefined(Constants.HttpPost))
                {
                    var keys = CheckKeyParameters(type, paras);
                    if (keys != null)
                    {
                        UnboundActions.AddOrUpdate(method.Name, new UnboundMethod(method, keys));
                    }
                    else
                    {
                        BoundActions.AddOrUpdate(method.Name, new BoundMethod(method));
                    }
                }
            }
        }
        private bool ProcessKeysBodyMethod(ClrTypeInfo type, MethodInfo method, EControllerMethodKind kind)
        {
            var paras = method.GetParameters();
            var keys = CheckKeyParameters(type, paras);
            if (keys != null && keys.Length == paras.Length)
            {
                if (paras.Length == keys.Length + 1 && paras[keys.Length].IsDefined(Constants.FromBody))
                {
                    Methods.AddOrUpdate(kind, new UnboundMethod(method, keys));
                    return true;
                }
            }
            return false;
        }
        private bool ProcessKeysMethod(ClrTypeInfo type, MethodInfo method, EControllerMethodKind kind)
        {
            var paras = method.GetParameters();
            var keys = CheckKeyParameters(type, paras);
            if (keys != null && keys.Length == paras.Length)
            {
                Methods.AddOrUpdate(kind, new UnboundMethod(method, keys));
                return true;
            }
            return false;
        }
        private bool ProcessBodyMethod(ClrTypeInfo type, MethodInfo method, EControllerMethodKind kind)
        {
            var paras = method.GetParameters();
            if (paras.Length == 1 && paras[0].IsDefined(Constants.FromBody))
            {
                Methods.AddOrUpdate(kind, new BoundMethod(method));
                return true;
            }
            return false;
        }
        private bool ProcessRefMethod(ClrTypeInfo type, MethodInfo method)
        {
            var paras = method.GetParameters();
            if (paras.Length == 2 && paras[0].ParameterType == typeof(string)
                && paras[1].IsDefined(Constants.FromBody))
            {
                var kind = method.Name == Constants.ActionCreateRef ? EControllerMethodKind.CreateRefBatch : EControllerMethodKind.DeleteRefBatch;
                Methods.AddOrUpdate(kind, new BoundFunctionMethod(method, paras[0].Name));
                return true;
            }
            else
            {
                var keys = CheckKeyParameters(type, paras);
                if (keys != null)
                {
                    if (paras.Length == keys.Length + 1 && method.Name == Constants.ActionDeleteRef)
                    {
                        var para = paras[keys.Length];
                        if (para.ParameterType == typeof(string))
                        {
                            Methods.AddOrUpdate(EControllerMethodKind.DeleteRefObject, new UnboundFunctionMethod(method, keys, para.Name));
                            return true;
                        }
                    }
                    else if (paras.Length == keys.Length + 2)
                    {
                        var navigate = paras[keys.Length];
                        var link = paras[keys.Length + 1];
                        if (navigate.ParameterType == link.ParameterType && link.ParameterType == typeof(string))
                        {
                            var kind = method.Name == Constants.ActionCreateRef ? EControllerMethodKind.CreateRef : EControllerMethodKind.DeleteRef;
                            Methods.AddOrUpdate(kind, new UnboundFunctionMethod(method, keys, navigate.Name, link.Name));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private string[] CheckKeyParameters(ClrTypeInfo type, ParameterInfo[] paras)
        {
            var keys = type.Keys;
            if (paras.Length < keys.Length)
            {
                return null;
            }
            var result = new string[keys.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                var para = paras[i];
                if (key.PropertyType != para.ParameterType)
                {
                    return null;
                }
                if (!para.IsDefined(Constants.FromODataUri))
                {
                    var name = Constants.KeyParameterName;
                    if (keys.Length > 1)
                    {
                        name += key.Name;
                    }
                    if (para.Name != name)
                    {
                        return null;
                    }
                }
                result[i] = para.Name;
            }
            return result;
        }
    }
}