using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RedisExchangeApiWebApp.Services;
using StackExchange.Redis;

namespace RedisExchangeApiWebApp.Controllers
{
    public class ListTypeController : Controller
    {
        private readonly RedisService _redis;
        private readonly IDatabase db;
        private string listKey = "names";

        public ListTypeController(RedisService redis)
        {
            _redis = redis;
            db = _redis.GetDb(1);
        }
        public IActionResult Index()
        {
            List<string> nameList = new List<string>();

            if (db.KeyExists(listKey))
            {
                db.ListRange(listKey).ToList().ForEach(x => {
                    nameList.Add(x.ToString());
                });
            }
            return View(nameList);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (name.StartsWith('a'))
            {
                db.ListLeftPush(listKey,name);
            }
            else
            {
                db.ListRightPush(listKey, name);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteItemAsync(string name)
        {
            await db.ListRemoveAsync(listKey, name);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFirstItem()
        {
            await db.ListLeftPopAsync(listKey);
            return RedirectToAction("Index");
        }
    }
}
