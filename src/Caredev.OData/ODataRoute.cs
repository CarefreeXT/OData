// Copyright (c) CarefreeXT and Caredev Studios. All rights reserved.
// Licensed under the GNU Lesser General Public License v3.0.
// See LICENSE in the project root for license information.
#if NETSTANDARD2_0
#else
namespace Caredev.OData
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Routing;
    internal class ODataRoute : HttpRoute
    {
        public ODataRoute(string routeTemplate, ODataConfiguration configuration) :
            base(routeTemplate)
        {
            Configuration = configuration;
        }

        public ODataConfiguration Configuration { get; }

        public override IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
        {
            var data = base.GetRouteData(virtualPathRoot, request);
            if (data != null)
            {
                var path = data.Values[Constants.ODataPath];
                data.Values.Add("controller", path);

            }
            return data;
        }
    }
}
#endif