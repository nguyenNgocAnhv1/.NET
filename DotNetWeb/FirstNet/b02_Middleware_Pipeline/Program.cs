namespace main
{
    public class Startup
    {
        //  Dang ky cac dich vu
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddSingleton<SecondMiddleware>();
        }
        // Xay dung pipeline (chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();   // use static files in wwwroot directory
            // app.UseMiddleware<FirstMiddleware>();
            app.UseFirstMiddleware(); // call function in class use first middleware
            app.UseSecondMiddleware();
            app.UseRouting();
            app.UseEndpoints((endpoint) =>
            {
                // E1
                endpoint.MapGet("/about.html", async (context) =>
                {
                    await context.Response.WriteAsync("Trang gioi thieu");
                });
                // E2
                endpoint.MapGet("/sanpham.html", async (context) =>
                {
                    await context.Response.WriteAsync("Trang san pham");
                });
            });
            // re nhanh pipeline
            app.Map("/admin", (app1) =>
            {
                app1.UseRouting();
                //BE1
                app1.UseEndpoints((endpoint) =>
                {
                    endpoint.MapGet("/user",async (context) =>{
                        await context.Response.WriteAsync("Trang quan ly user");
                    });
                });
                //BE2
                app1.UseEndpoints((endpoint) =>
                {
                    endpoint.MapGet("/stander",async (context) =>{
                        await context.Response.WriteAsync("Tieu chuan");
                    });
                });
                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Trang admin");
                });
            });
            // Terminate middleware M1
            app.Run(async (context) =>
            {

                await context.Response.WriteAsync("Hello asp net!");
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
/*
pipeline:Static file 
    - FirstMiddleware 
        - Second middllware 
            - Endpoint Middleware (E1, E2)
                - Re nhanh pipeline BE1, BE2
                - M1
*/