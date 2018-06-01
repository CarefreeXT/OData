// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
#if NETSTANDARD2_0
//namespace Microsoft.Extensions.DependencyInjection
#else
namespace Caredev.OData
{
    using Caredev.OData.Core;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    public static class ODataServiceExtensions
    {
        public static void MapODataRout(this HttpRouteCollection routes, string name, string routePrefix, ODataConfiguration configuration)
        {
            var routeTemplate = Constants.ODataRouteTemplate;
            if (!string.IsNullOrEmpty(routePrefix) && !string.IsNullOrWhiteSpace(routePrefix))
            {
                routeTemplate = routePrefix.TrimEnd('/', '\\') + "/" + routeTemplate;
            }
            var route = new ODataRoute(routeTemplate, configuration);
            configuration.Initialize();
            routes.Add(name, route);
        }

        static void Test(HttpConfiguration config)
        {
            var asmResolver = config.Services.GetAssembliesResolver();
            var typeResolver = config.Services.GetHttpControllerTypeResolver();
            var selector = config.Services.GetHttpControllerSelector();
            var mapping = selector.GetControllerMapping();

            foreach (var item in mapping.Values)
            {

            }

            var types = typeResolver.GetControllerTypes(asmResolver);
        }

        public static IClrTypeKeyResolver GetClrTypeKeyResolver(this ServicesContainer services)
        {
            var resolver = services.GetService(typeof(IClrTypeKeyResolver)) as IClrTypeKeyResolver;
            if (resolver == null)
            {
                resolver = new DefalutClrTypeKeyResolver();
                services.Add(typeof(IClrTypeKeyResolver), resolver);
            }
            return resolver;
        }
    }
}
#endif