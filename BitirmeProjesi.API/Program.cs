using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BitirmeProjesi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var webHost = /*WebHost.CreateDefaultBuilder(args)
                .UseUrls($"https://192.168.1.12:{config.GetValue<int>("Host:Port")}")
                .UseKestrel()
                .UseStartup<Startup>();
                */          WebHost.CreateDefaultBuilder(args)
                            .UseKestrel(options => {
                                options.Listen(IPAddress.Loopback, 44354); //HTTP port
                            })
                            .UseStartup<Startup>();
            return webHost;
        }

    }
}
