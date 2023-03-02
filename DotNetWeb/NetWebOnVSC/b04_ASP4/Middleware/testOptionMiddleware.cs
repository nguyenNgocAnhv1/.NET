using System.Text;
using Microsoft.Extensions.Options;

public class TestOptionsMiddleware : IMiddleware
{
    TestOptions testOptions { get; set; }
    ProductName productName { get; set; }
    public TestOptionsMiddleware(IOptions<TestOptions> options, ProductName product)
    {
        testOptions = options.Value;
        productName = product;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Show options in TestoptionsMiddleware\n");
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Test options: \n");
        stringBuilder.Append("opt_key1 = " + testOptions.opt_key1);
        stringBuilder.Append("\nTestOption.opt_key2.k1 = " + testOptions.opt_key2.k1);
        stringBuilder.Append("\nTestOption.opt_key2.k2 = " + testOptions.opt_key2.k2);
        foreach (var name in productName.GetNames())
        {
            stringBuilder.Append(name + "\n");
        }
        await context.Response.WriteAsync(stringBuilder.ToString());

        await next(context);
    }
}