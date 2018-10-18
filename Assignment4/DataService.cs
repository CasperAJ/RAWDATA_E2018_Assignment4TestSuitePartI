using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4
{
    public class DataService
    {
        // Creates a Global db variable
        Assignment4Context db = new Assignment4Context();

        // Get Product by id
        public Product GetProduct(int wantedId)
        {
            var fetchedProduct = new Product();

            var dataSource = db.Products;
            var linqQuery = dataSource.Where(x => x.Id.Equals(wantedId))
                .Select(x => new {x.Name, x.UnitPrice, x.Category});

            foreach (var productData in linqQuery)
            {
                fetchedProduct.Name = productData.Name;
                fetchedProduct.UnitPrice = productData.UnitPrice;
                fetchedProduct.Category = productData.Category;
            }
            return fetchedProduct;
        }

        // Get Product by name
        // Doest not work completely as is only returns 1 rather than 3
        public List<Product> GetProductByName(string wantedName)
        {
            var productList = new List<Product>();

            var dataSource = db.Products;
            var linqQuery = dataSource.Where(x => x.Name.Contains(wantedName))
                .Select(x => new {x.Name, x.Category});

            foreach (var product in linqQuery)
            {
                var newProd = new Product();
                newProd.Name = product.Name;
                newProd.Category = product.Category;

                productList.Add(newProd);
            }
            return productList;
        }
    }
}
