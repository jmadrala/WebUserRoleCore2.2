using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebUserRole.Models;

namespace WebUserRole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run(); // Orginal 

            // Added
            var host = CreateWebHostBuilder(args).Build();

            var configuration = host.Services.GetRequiredService<IConfiguration>();
            using (var scope = host.Services.CreateScope())
            {
                SeedUserRole.CreateRoles(scope.ServiceProvider, configuration).Wait();
            }
            host.Run();
            //---
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
