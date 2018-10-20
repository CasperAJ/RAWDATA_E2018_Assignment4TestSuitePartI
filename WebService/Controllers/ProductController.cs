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

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
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
    }
}
