using Caredev.OData.Tests.TestSite.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Caredev.OData.Tests.TestSite.App_Start
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var configure = new ODataConfiguration(config);

            configure.Register<Customer>("Customers");

            config.Routes.MapODataRout("odata", "odata", configure);

            appBuilder.UseWebApi(config);
        }
    }
}
