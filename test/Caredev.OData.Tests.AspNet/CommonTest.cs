using System;
using Caredev.OData.Core;
using Caredev.OData.Core.Controllers;
using Caredev.OData.Tests.TestSite.Controllers;
using Caredev.OData.Tests.TestSite.Models;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caredev.OData.Tests
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var info = HttpHelper.Get("odata/Orders");
        }


        [TestMethod]
        public void TestMehtod2()
        {
            var resolver = new DefalutClrTypeKeyResolver();
            var info = new ClrTypeInfo(typeof(Customer), resolver);
            var con = new ControllerInfo(info, typeof(CustomersController), "Customers");
        }
    }
}
