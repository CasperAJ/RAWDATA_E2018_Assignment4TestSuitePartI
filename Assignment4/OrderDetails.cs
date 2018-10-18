using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    [Table("orderdetails")]
    public class OrderDetails
    {
        [Column("orderid")]
        public int Id { get; set; } // Hvorfor skal den her være der?

        [Column("orderid")]
        public int OrderId { get; set; }

        [Column("product")]
        public int ProductId { get; set; }

        [Column("unitprice")]
        public int UnitPrice { get; set; }

        [Column("quantity")]
        public string Quantity { get; set; }

        [Column("discount")]
        public int Discount { get; set; }

        public Order Order { get; set; } // Hvorfor skal den her være der?
        public Product Product { get; set; } // Hvorfor skal den her være der?
    }
}
