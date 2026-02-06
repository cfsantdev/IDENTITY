using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AvatarManagement
{
    public class Program
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
                    webBuilder.UseKestrel();
                    webBuilder.UseIISIntegration();
                    webBuilder.UseUrls("https://localhost:5003");
                });
    }
}
