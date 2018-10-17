using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    [Table("orders")]
    public class Order
    {
        [Column("orderid")]
        public int Id { get; set; }

        [Column("orderdate")]
        public DateTime Date { get; set; }

        [Column("requiredate")]
        public DateTime Require { get; set; }

        [Column("shippeddate")]
        public DateTime Shipped { get; set; }

        [Column("freight")]
        public int Freight { get; set; }

        [Column("shipname")]
        public string ShipName { get; set; }

        [Column("shipcity")]
        public string ShipCity { get; set; }
    }
}
