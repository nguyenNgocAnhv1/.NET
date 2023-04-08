namespace main
{
    public class MyStartUp
    {
        //  Dang ky cac dich vu
        public void ConfigureServices(IServiceCollection service)
        {
            //service.AddSingleton
        }
        // Xay dung pipeline (chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            // The method for specify content with link
            app.UseRouting();
            app.UseEndpoints(enpoint =>
            {
                enpoint.MapGet("/", async (context) =>
                {
                    await context.Response.WriteAsync("Trang chu");
                });
                enpoint.MapGet("/about", async (context) =>
                {
                    string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
    ";
                    
                    await context.Response.WriteAsync(html);
                });
            });
            app.Map("/abc", async app1 =>
            {
                app1.Run(async (HttpContext context) =>
                {
                    await context.Response.WriteAsync("Noi dung tu abc");
                });
            });
            app.UseStatusCodePages(); // set contents if the link is wrong

            //app.Run(async (HttpContext context) =>
            //{
            //    await context.Response.WriteAsync("<h1>Hello world <h1>");
            //});


        }
    }
    class main
    {
        public static void Theory()
        {


        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Start app");
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            // Cau hinh mac dinh
            builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
            {
                // Tuy bien them
                //webBuilder.
                //webBuilder.UseWebRoot("tenFolder"); // change folder for method use static file, default is wwwroot
                webBuilder.UseStartup<MyStartUp>();
            });
            IHost host = builder.Build();
            host.Run();

        }
    }
}
/*
 Host (IHost) object:
    - Dependency Injection (ID): IServiceProvider (ServiceCollection)
    - Logging (ILogging)
    - Configuration
    - IHostedService => StartAsyn: Run HTML Server 
 1. Tạo IHostBuilder
 2. Cấu hình đăng ký các dịch vụ (gói ConfigureWebHostDefaults)
 3. IhostBuilder.build() => Host (IHost)
 */