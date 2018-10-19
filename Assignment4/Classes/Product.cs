using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment4
{
    [Table("products")]
    public class Product
    {
        [Column("productid")]
        public int Id { get; set; }

        [Column("productname")]
        public string Name { get; set; }

        [Column("unitprice")]
        public int UnitPrice { get; set; }

        [Column("quantityperunit")]
        public string QuantityPerUnit { get; set; }

        [Column("unitsinstock")]
        public int UnitsInStock { get; set; }

        [Column("categoryid")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

