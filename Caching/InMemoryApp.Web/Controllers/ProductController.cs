using InMemoryApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Globalization;

namespace InMemoryApp.Web.Controllers
{

    // In - memory cache !!!
    public class ProductController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        public ProductController(IMemoryCache memoryCache)
        {
            //DI
            _memoryCache= memoryCache;
        }
        public IActionResult Index()
        {
            // 1. yol
            //if (String.IsNullOrEmpty(_memoryCache.Get<string>("zaman")))
            //{
            //    _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
            //}
            // 2.yok

            if (!_memoryCache.TryGetValue("zaman",out string zamanCache))
            {
                MemoryCacheEntryOptions options  = new MemoryCacheEntryOptions();

                options.AbsoluteExpiration = DateTime.Now.AddSeconds(10);
                options.SlidingExpiration = TimeSpan.FromSeconds(5);

                options.RegisterPostEvictionCallback((key,value,reason,state) =>
                {
                    _memoryCache.Set("callBack", $"key : {key} --> value : {value} --> reason : {reason} --> state : {state}");
                });

                _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), options);
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                .SetPriority(CacheItemPriority.Normal)
                .SetSize(1024);
            Product product = new Product { Id = 1 , Name = "Pencil" };

            _memoryCache.Set<Product>("Product:1", product);
            return View();
        }

        public IActionResult Show()
        {
            _memoryCache.Remove("zaman"); // memory cache den silme !
            _memoryCache.GetOrCreate<string>("zaman", entry =>
            {
               return DateTime.Now.ToString();
            });
            ViewBag.zaman = _memoryCache.Get<string>("zaman");
            ViewBag.product = _memoryCache.Get<Product>("Product:1");
            return View();
        }
    }
}
