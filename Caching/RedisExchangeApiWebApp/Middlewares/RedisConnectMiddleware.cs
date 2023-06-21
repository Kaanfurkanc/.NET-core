using RedisExchangeApiWebApp.Services;

namespace RedisExchangeApiWebApp.Middlewares
{
    public class RedisConnectMiddleware
    {
        private readonly RequestDelegate _next;
        public RedisConnectMiddleware(RequestDelegate next) 
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context , RedisService redisService)
        {
            redisService.Connect();
            await _next.Invoke(context);
        }
    }
}
