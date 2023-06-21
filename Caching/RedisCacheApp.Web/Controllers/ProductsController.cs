using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisCacheApp.Web.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RedisCacheApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public ProductsController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task<IActionResult> Index()
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                SlidingExpiration = TimeSpan.FromSeconds(20),
            };

            await _distributedCache.SetStringAsync("country", "turkey",options);

            Product product = new Product { Id = 2, Name = "Phone" };

            string jsonProduct = JsonSerializer.Serialize(product);
            await _distributedCache.SetStringAsync("product:1", jsonProduct, options);
            return View();
        }

        public async Task<IActionResult> Show()
        {
            var country = await _distributedCache.GetStringAsync("country");

            string jsonProduct = _distributedCache.GetString("product:1");
            Product p = JsonSerializer.Deserialize<Product>(jsonProduct);

            return View();
        }

        public async Task<IActionResult> Remove()
        {
            await _distributedCache.RemoveAsync("country");
            return View();
        }

        public async Task<IActionResult> ImageUrl()
        {
            byte[] imageByte = await _distributedCache.GetAsync("redApple");

            return File(imageByte,"image/jpg");
        }
        public async Task<IActionResult> CacheImage()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/apple.jpg");

            byte[] imageByte = System.IO.File.ReadAllBytes(path);
            _distributedCache.Set("redApple", imageByte);
            return View();
        }
    }
}
