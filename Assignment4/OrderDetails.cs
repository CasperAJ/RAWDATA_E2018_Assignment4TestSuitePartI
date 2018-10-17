using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    [Table("orderdetails")]
    public class OrderDetails
    {
        [Column("unitprice")]
        public int UnitPrice { get; set; }

        [Column("quantity")]
        public string Quantity { get; set; }

        [Column("discount")]
        public int Discount { get; set; }
    }
}
