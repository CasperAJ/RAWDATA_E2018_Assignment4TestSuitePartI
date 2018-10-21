using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment4;
using Microsoft.AspNetCore.Mvc;
using WebService.View;

namespace WebService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        DataService dataService = new DataService();

        // Get product by Id - Task 6
        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var product = dataService.GetProduct(productId);

            if (product.Name == null && product.Category == null)
            {
                return NotFound();
            }

            var productView = new ProductView();
            productView.Name = product.Name;
            productView.UnitPrice = product.UnitPrice;
            productView.CategoryName = product.Category.Name;

            return Ok(productView);
        }

        // Product by category - Task 7
        [HttpGet("name/{findProduct}")]
        public IActionResult GetProductByCategory(string findProduct)
        {
            var product = dataService.GetProductByName(findProduct);
            var productList = new List<Product>();

            if (product.Count == 0)
            {
                return NotFound(product);
            }

            foreach (var productFound in product)
            {
                var newProduct = new Product();
                newProduct.Name = productFound.Name;
                newProduct.Category = productFound.Category;

                productList.Add(newProduct);
            }
            return Ok(productList);
        }
    }
}
