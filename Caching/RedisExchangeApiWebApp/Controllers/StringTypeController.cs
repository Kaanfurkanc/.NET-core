using Microsoft.AspNetCore.Mvc;
using RedisExchangeApiWebApp.Services;
using StackExchange.Redis;

namespace RedisExchangeApiWebApp.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redis;
        private readonly IDatabase db;

        public StringTypeController(RedisService redis)
        {
            _redis = redis;
            db = _redis.GetDb(1);
        }
        public IActionResult Index()
        {
            db.StringSet("name", "Kaan Furkan Çakıroğlu");
            db.StringSet("ziyaretçi", 1000);

            return View();
        }

        public async Task<IActionResult> ShowAsync()
        {
            var value = await db.StringGetAsync("name");
            value = db.StringGetRange("name", 0, 2);
            value = db.StringLength("name");
            
            await db.StringIncrementAsync("ziyaretçi",2);
            var count = await db.StringDecrementAsync("ziyaretçi", 23);
            if (value.HasValue)
            {
                ViewBag.value = value.ToString();
            }
            return View();
        }
    }
}
