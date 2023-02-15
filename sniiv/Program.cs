using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Elastic.Apm.SerilogEnricher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Sinks.Elasticsearch;
using Elastic.CommonSchema.Serilog;

namespace sniiv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String dir = Directory.GetCurrentDirectory() +"/wwwroot/" + "LogSNIIV.txt";
            Log.Logger = new LoggerConfiguration()
                //.Enrich.WithElasticApmCorrelationInfo()
                //.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("https://bedb8f9c815c4d89a3244df9ece6a164.apm.us-east4.gcp.elastic-cloud.com:443"))
                //{ CustomFormatter = new EcsTextFormatter()})
                .WriteTo.File(dir)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureLogging(logger =>
            {
                logger.AddConsole(x => x.TimestampFormat = "[ddd dd MMM yy HH:mm:ss]");
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://0.0.0.0:5000").UseStartup<Startup>()
                     .ConfigureKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3); });
                });
    }
}
