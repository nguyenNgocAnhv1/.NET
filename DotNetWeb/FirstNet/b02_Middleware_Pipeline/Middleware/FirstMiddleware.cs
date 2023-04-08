public class FirstMiddleware{
    private readonly RequestDelegate _next;
    public FirstMiddleware(RequestDelegate next){
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context){
        System.Console.WriteLine("Url: " + context.Request.Path);
        var message = "<p>Url: " + context.Request.Path+"</p>";
        context.Items.Add("DataFirstMiddleware",message);
        // context.Response.WriteAsync("<p>Url: " + context.Request.Path+"</p>");
        await _next(context);
    }
}