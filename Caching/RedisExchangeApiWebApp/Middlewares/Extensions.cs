namespace RedisExchangeApiWebApp.Middlewares
{
    public static class Extensions
    {
        public static IApplicationBuilder UseRedisConnect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RedisConnectMiddleware>();
        }
    }
}
