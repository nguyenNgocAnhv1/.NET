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
            app.UseRouting();

            app.UseEndpoints(enpoints =>
            {
                enpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("hello world");
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
