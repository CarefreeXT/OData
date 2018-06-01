using Caredev.Mego.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests.TestSite.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
        
        public string Zip { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [InverseProperty("CustomerId", "Id")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
