﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;

namespace RabbitMQ_Profiller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                
                .Build();

            var handler = (MessageHandler)host.Services.GetService(typeof(IMessageHandler));

            handler.StartListening();

            host.Run();
        }
    }
}
