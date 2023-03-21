using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Core;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product> {
                new Product{ID = 1, Name = "Pencil",Price = 10.99M,Stock = 490 },
                new Product{ID = 2,Name="Glasses",Price = 1450.45M,Stock = 1000}
        };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<Product>> GetById(int id)
        {
            foreach (var item in products)
            {
                if(item.ID == id)
                    return Ok(item);
            }
            return BadRequest("no found product by id");
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut]

        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var _product = products.Find(x => x.ID == product.ID);

            if (_product == null)
                return BadRequest("Can not found product by your id");

            _product.Name = product.Name;
            _product.Price = product.Price;
            _product.Stock = product.Stock;

            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            foreach (var item in products)
            {
                if (item.ID == id)
                    products.Remove(item);
            }
            return Ok(products);
        }
    }
}
