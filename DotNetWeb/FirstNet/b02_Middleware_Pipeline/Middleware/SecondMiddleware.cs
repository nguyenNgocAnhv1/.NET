public class SecondMiddleware : IMiddleware
{
    /*
        Url: /xxx.html
            - Khong goi Middleware phia sau
            - Ban khong duoc truy cap
            - Headle - SecondMiddleware: Ban khong duoc truy cap
        Url != /xxx.html
            - Headle - SecondMiddleware: Ban duoc truy cap
            - Chuyen qua httpcontext cho Middleware phia sau
    */
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path == "/xxx.html")
        {
            context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
            var dataFromFirst = context.Items["DataFirstMiddleware"];
            if (dataFromFirst != null)
            {
                await context.Response.WriteAsync((string)dataFromFirst);
            }
            await context.Response.WriteAsync("Ban khong duoc truy cap");

        }
        else
        {
            context.Response.Headers.Add("SecondMiddleware", "Ban  duoc truy cap");
            var dataFromFirst = context.Items["DataFirstMiddleware"];
            if (dataFromFirst != null)
            {
                await context.Response.WriteAsync((string)dataFromFirst);
            }
            await next(context);

        }
    }
}