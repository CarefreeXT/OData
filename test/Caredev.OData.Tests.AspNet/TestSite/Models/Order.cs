using Caredev.Mego.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caredev.OData.Tests.TestSite.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime ModifyDate { get; set; } = DateTime.Now;

        public int State { get; set; }

        [ForeignKey("CustomerId", "Id")]
        public virtual Customer Customer { get; set; }

        [InverseProperty("OrderId", "Id")]
        public virtual ICollection<OrderDetail> Details { get; set; }

        [Relationship(typeof(OrderDetail), "OrderId", "Id", "ProductId", "Id")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
