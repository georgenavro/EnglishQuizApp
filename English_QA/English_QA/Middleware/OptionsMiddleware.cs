namespace English_QA.Middleware
{
    public class OptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public OptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }
        private Task BeginInvoke(HttpContext context)
        {
            try
            {
                if (context.Request.Method == "OPTIONS")
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "Origin" });
                    context.Response.Headers.Append("Access-Control-Allow-Headers", new[] { "Origin", "X-Requested-With", "Content-Type", "Accept", "Authorization" });
                    context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" });
                    context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync("OK");
                }
                else
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "http://localhost:5173" });
                }
                return _next.Invoke(context);
            }
            catch
            {
                return _next.Invoke(context);
            }
        }
    }
    public static class OptionsMiddleWareExtensions
    {
        public static IApplicationBuilder useOptions(this IApplicationBuilder app) 
        {
        return app.UseMiddleware<OptionsMiddleware>();
        }
    }
}
