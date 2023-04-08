using System.Text;
using Microsoft.Extensions.Options;

namespace main
{
    public class Startup
    {
        IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //  Dang ky cac dich vu
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<TestOptionsMiddleware>();
            service.AddSingleton<ProductName>();
            service.AddOptions();
            var testOptions = _configuration.GetSection("TestOptions");
            service.Configure<TestOptions>(testOptions);

        }
        // Xay dung pipeline (chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<TestOptionsMiddleware>();
            app.UseRouting(); 

            app.UseEndpoints(enpoints =>
            {
                enpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("hello world");
                });
                enpoints.MapGet("/ShowOptions", async context =>
                {
                    // var configuration = context.RequestServices.GetService<IConfiguration>();
                    // Lay theo kieu section
                    // var testOptions = configuration.GetSection("TestOptions");                    
                    // var opt_key1 =  testOptions["opt_key1"];
                    // var k1 =  testOptions.GetSection("opt_key2")["k1"];
                    // var k2 =  testOptions.GetSection("opt_key2")["k2"];
                    // Lay theo kieu object 
                    var testOptions = context.RequestServices.GetService<IOptions<TestOptions>>().Value;
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append("Test options: \n");
                    stringBuilder.Append("opt_key1 = " + testOptions.opt_key1);
                    stringBuilder.Append("\nTestOption.opt_key2.k1 = " + testOptions.opt_key2.k1);
                    stringBuilder.Append("\nTestOption.opt_key2.k2 = " + testOptions.opt_key2.k2);
                    await context.Response.WriteAsync(stringBuilder.ToString());




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
