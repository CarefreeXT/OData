// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
#if NETSTANDARD2_0
#else
namespace Caredev.OData
{
    using Caredev.OData.Core.Controllers;
    using Caredev.OData.Core.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public class ODataConfiguration
    {
        public ODataConfiguration(HttpConfiguration configuration)
        {
            HttpConfiguration = configuration;
        }

        internal HttpConfiguration HttpConfiguration { get; }

        private readonly Dictionary<string, Type> registerClrType;

        internal IReadOnlyDictionary<string, ControllerInfo> Controllers { get; private set; }

        public void Register<T>(string controllerName)
        {
            registerClrType.AddOrUpdate(controllerName, typeof(T));
        }

        internal void Initialize()
        {
            if (!IsInitialized)
            {
                var config = HttpConfiguration;
                var asmResolver = config.Services.GetAssembliesResolver();
                var typeResolver = config.Services.GetHttpControllerTypeResolver();
                var selector = config.Services.GetHttpControllerSelector();
                var mapping = selector.GetControllerMapping();

                var keyresolver = config.Services.GetClrTypeKeyResolver();

                var items = new Dictionary<string, ControllerInfo>();
                foreach (var kv in registerClrType)
                {
                    if (mapping.TryGetValue(kv.Key, out HttpControllerDescriptor controller))
                    {
                        var info = new ClrTypeInfo(kv.Value, keyresolver);
                        var con = new ControllerInfo(info, controller.ControllerType, controller.ControllerName);
                    }
                }
                Controllers = items.AsReadOnly();
            }
        }
        private bool IsInitialized = false;
    }
}
#endif
