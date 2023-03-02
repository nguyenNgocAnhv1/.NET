var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    // options.RootDirectory = "/Contents"; change root directory
    // options.Conventions.AddPageRoute("/FirstPage","trang-dau-tien"); rewrite link (way 1 )
});
builder.Services.Configure<RouteOptions>(routeOptions =>
{
    routeOptions.LowercaseUrls =true;
});
var app = builder.Build();
app.MapRazorPages();   // FirstPage => SecondPage => ThirdPage
app.MapGet("/", () => "Hello World!");
app.Run();
/*
    Razor pages (.cshtml) = html + c#
    Engine Razor - bien dich cshtml  -> Response
    - @page or @page"url" -> rewrite
        -Neu co folder ben trong 
    - @bien, @bieuthuc
    - @{
        code c#
        <html> <html>
    }
    Rewrite url
    Tag helper -> html
    @addTagHelper *,Microsoft.AspNetCore.Mvc.TagHelpers
*/