using Caredev.OData.Tests.TestSite.App_Start;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests
{
    public static class HttpHelper
    {
        private readonly static string _BaseAddress = "http://localhost:9000/";

        static HttpHelper()
        {
            WebApp.Start<Startup>(url: _BaseAddress);
        }

        public static HttpResponseMessage Get(string address)
        {
            var client = new HttpClient();
            var task = client.GetAsync(_BaseAddress + address);
            task.Wait();
            Output(task.Result);
            return task.Result;
        }

        public static string GetString(string address)
        {
            var client = new HttpClient();
            var task = client.GetStringAsync(_BaseAddress + address);
            task.Wait();
            Debug.WriteLine(task.Result);
            return task.Result;
        }
        
        static void Output(HttpResponseMessage response)
        {
            Debug.WriteLine("响应内容：");
            Debug.WriteLine(response);
            Debug.WriteLine("响应正文：");
            Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
            Debug.WriteLine("");
        }
    }
}
