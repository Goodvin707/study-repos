using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebLabsV05.Extensions;
using WebLabsV05.Services;

namespace WebLabsV05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(log =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "fileInfoLog.txt");
                log.ClearProviders();
                log.AddFileLogger(path); 
                //log.AddProvider(new FileLoggerProvider(path));
                log.AddFilter("Microsoft", LogLevel.None);
                log.AddFilter("System", LogLevel.None);
            })           
            .UseStartup<Startup>();
    }
}
