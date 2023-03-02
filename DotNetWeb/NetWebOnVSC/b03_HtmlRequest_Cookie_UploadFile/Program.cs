using Newtonsoft.Json;

namespace main
{
    public class Startup
    {
        //  Dang ky cac dich vu
        public void ConfigureServices(IServiceCollection service)
        {

        }
        // Xay dung pipeline (chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(enpoints =>
            {
                enpoints.MapGet("/", async context =>
                {
                    var menu = HtmlHelper.MenuTop(

                            HtmlHelper.DefaultMenuTopItems()
                        , context.Request
                    );
                    var html = HtmlHelper.HtmlDocument("Xin chao", menu + HtmlHelper.HtmlTrangchu());

                    await context.Response.WriteAsync(html);
                });
                enpoints.MapGet("/RequestInfo", async context =>
                {
                    var menu = HtmlHelper.MenuTop(

                            HtmlHelper.DefaultMenuTopItems()
                        , context.Request
                    );
                    var info = RequestProcess.RequestInfor(context.Request).HtmlTag("div", "container");
                    var html = HtmlHelper.HtmlDocument("Thong tin request", menu + info);

                    await context.Response.WriteAsync(html);
                });
                enpoints.MapGet("/Encoding", async context =>
                {
                    await context.Response.WriteAsync("Encoding");
                });
                enpoints.MapGet("/Json", async context =>
                {
                    var p = new
                    {
                        TenSp = "Xiaomi",
                        Gia = 5000,
                        Date = new DateTime(2023, 1, 3)
                    };
                    context.Response.ContentType = "application/json";
                    var json = JsonConvert.SerializeObject(p);

                    await context.Response.WriteAsync(json);
                });
                enpoints.MapGet("/Cookies/{*action}", async context =>
                {
                    var menu = HtmlHelper.MenuTop(

                            HtmlHelper.DefaultMenuTopItems()
                        , context.Request
                    );
                    var action = context.GetRouteValue("action") ?? "read";
                    string mess = "";
                    if (action.ToString() == "write")
                    {
                        var options = new CookieOptions()
                        {
                            Path = "/",
                            Expires = DateTime.Now.AddDays(2),
                        };
                        context.Response.Cookies.Append("Ma_san_pham", "Iphone");
                        mess = "Cookies da duoc ghi";

                    }
                    else
                    {
                        var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                        mess = string.Join("", listcokie).HtmlTag("ul");
                    }
                    mess = mess.HtmlTag("div", "alert alert-danger");
                    var huongDan = "<a href= \"/Cookies/read\">Doc cookies </a><br><a href= \"/Cookies/write\">Ghi cookies </a>";
                    huongDan = huongDan.HtmlTag("div", "container");
                    var html = HtmlHelper.HtmlDocument("Cookies - " + action, menu + huongDan + mess);

                    await context.Response.WriteAsync(html);
                });
                enpoints.MapMethods("/Form", new string[]{"POST","GET"}, async context =>
                {
                    var menu = HtmlHelper.MenuTop(

                            HtmlHelper.DefaultMenuTopItems()
                        , context.Request
                    );
                    var formhtml = RequestProcess.ProcessForm(context.Request);
                    var html = HtmlHelper.HtmlDocument("Test submit form", menu + formhtml);

                    await context.Response.WriteAsync(html);
                    
                });
            });
        }
    }
    class main
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
