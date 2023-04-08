namespace main
{
    public class Startup
    {
        //  Dang ky cac dich vu
        public void ConfigureServices(IServiceCollection service)
        {
            // service.AddDistributedMemoryCache();
            service.AddDistributedSqlServerCache((option) =>
            {
                option.ConnectionString = "Data Source=NGOCANH\\SQLEXPRESS;Initial Catalog=Test;User ID=sa;Password=123456;TrustServerCertificate=True;";
                option.SchemaName="dbo";
                option.TableName = "sesstion";
            });

            service.AddSession((option) =>
            {
                option.Cookie.Name = "ngocanh";
                option.IdleTimeout = new TimeSpan(0, 30, 0);
            });

        }
        // Xay dung pipeline (chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession(); // SessionMiddleware - Cookie (ID session)
            app.UseRouting();

            app.UseEndpoints(enpoints =>
            {
                enpoints.MapGet("/", async context =>
                {
                    // context.Session
                    int? count;
                    count = context.Session.GetInt32("count");
                    if (count == null)
                    {
                        count = 0;
                    }
                    await context.Response.WriteAsync($"So lan truy cap la: " + count);

                    await context.Response.WriteAsync("\nhello world");
                });
                enpoints.MapGet("/readwritesession", async (context) =>
                {
                    int? count;
                    count = context.Session.GetInt32("count");
                    if (count == null)
                    {
                        count = 0;
                    }
                    count = count + 1;
                    context.Session.SetInt32("count", count.Value);
                    await context.Response.WriteAsync($"So lan truy cap la: " + count);

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

// dotnet sql-cache create "Data Source=NGOCANH\SQLEXPRESS;Initial Catalog=Test;User ID=sa;Password=123456;TrustServerCertificate=True;" dbo sesstion