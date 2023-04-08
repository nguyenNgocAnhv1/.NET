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
            service.AddOptions();
            var mailsettings = _configuration.GetSection("MailSetting");
            service.Configure<MailSetting>(mailsettings);
            service.AddTransient<SendMailService>();
        }
        /*
            Mail server - Smtp
            Smtp client
            Server: Mail Transporter 
         */
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
                enpoints.MapGet("/testsendmail", async context =>
                {
                    var message = await MailUtils.MailUtils.SendMail("keyhmast1@gmail.com", "keyhmast1@gmail.com", "Test", "Xin chao");
                    await context.Response.WriteAsync(message);

                });
                enpoints.MapGet("/testgmail", async context =>
                {
                    var message = await MailUtils.MailUtils.SendGmail("keyhmast1@gmail.com", "keyhmast1@gmail.com", "Test", "Xin chao", "keyhmast1@gmail.com", "anh292003");
                    await context.Response.WriteAsync(message);

                });
                enpoints.MapGet("/testsendmailservice", async context =>
                {
                    var SendMailService = context.RequestServices.GetService<SendMailService>();
                    var mailContent = new MailContent();
                    mailContent.to= "keyhmast1@gmail.com";
                    mailContent.subject = "Kiem tra";
                    mailContent.body = "<h1> test </h1>" ;
                    var kq = await SendMailService.SendMail(mailContent);
                    await context.Response.WriteAsync(kq);

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
