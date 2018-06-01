using Caredev.OData.Tests.TestSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Caredev.OData.Tests.TestSite.Controllers
{
    public class CustomersController : ODataController
    {

        private OrderManageEntities db = new OrderManageEntities();
        // GET odata/Customers
        [HttpGet]
        public IQueryable<Customer> Get()
        {
            return db.Customers.Take(10);
        }
        // GET odata/Customers(1)
        public Customer Get(int key)
        {
            return db.Customers.FirstOrDefault(a => a.Id == key);
        }
        // GET odata/Customers(1)/Orders
        public IQueryable<Order> GetOrders(int key)
        {
            return db.Orders.Where(a => a.CustomerId == key);
        }
        // GET odata/Customers/Function(1,@para2)
        [HttpGet]
        public IHttpActionResult Function(int para1, object para2)
        {
            throw new NotImplementedException();
        }
        // GET odata/Customers(1)/Function(1,@para2)
        [HttpGet]
        public IHttpActionResult Function(int key, int para1, object para2)
        {
            throw new NotImplementedException();
        }

        // POST odata/Customers
        public IHttpActionResult Post([FromBody]Customer[] customer)
        {
            return Ok(customer);
        }
        // POST odata/Customers/Action(1,@para2)
        [HttpPost]
        public IHttpActionResult Action(int para1, object para2)
        {
            throw new NotImplementedException();
        }
        // POST odata/Customers(1)/Action(1,@para2)
        [HttpPost]
        public IHttpActionResult Action(int key, int para1, object para2)
        {
            throw new NotImplementedException();
        }

        // PUT/PATCH odata/Customers
        public IHttpActionResult Put([FromBody]Customer[] customers)
        {
            return Ok();
        }
        // PUT/PATCH odata/Customers(1)
        public IHttpActionResult Put(int key, [FromBody]Customer customer)
        {
            return Ok(customer);
        }

        // DELETE odata/Customers(1)
        public IHttpActionResult Delete(int key)
        {
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE odata/Customers
        public IHttpActionResult Delete([FromBody]Customer[] customers)
        {
            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST/PUT odata/Customers/Orders/$ref
        public IHttpActionResult CreateRef(string navigateProperty, [FromBody]object[] pairs)
        {
            throw new NotImplementedException();
        }
        // POST/PUT odata/Customers(1)/Orders/$ref?$id=Orders(1)
        public IHttpActionResult CreateRef(int key, string navigateProperty, string link)
        {
            throw new NotImplementedException();
        }

        // DELETE odata/Customers/Orders/$ref
        public IHttpActionResult DeleteRef(string navigateProperty, [FromBody]object[] pairs)
        {
            throw new NotImplementedException();
        }
        // DELETE odata/Customers(1)/Orders/$ref?$id=Orders(1)
        public IHttpActionResult DeleteRef(int key, string navigateProperty, string link)
        {
            throw new NotImplementedException();
        }
        // DELETE odata/Customers(1)/Orders/$ref
        public IHttpActionResult DeleteRef(int key, string navigateProperty)
        {
            throw new NotImplementedException();
        }
    }
}
