using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TrafiCarSharingAPI.Core.Helpers;

namespace TrafiCarSharingAPI.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            DatabaseInitializer.Initialize();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
