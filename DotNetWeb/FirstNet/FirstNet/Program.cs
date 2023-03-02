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
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
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
                    await context.Response.WriteAsync("Gioi thieu");
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