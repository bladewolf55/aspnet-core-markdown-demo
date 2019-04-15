using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCore1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //To use startup class naming conventions
                .UseStartup(typeof(Startup).GetTypeInfo().Assembly.FullName);
                //To use a single Startup class + method naming conventions
                //.UseStartup<Startup>();


        //Probably the better way for class naming conventions. It's what's shown in MS documentation.
        //public static IWebHostBuilder CreateWebHostBuilderOtherWay(string[] args)
        //{
        //    string assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

        //    return WebHost.CreateDefaultBuilder(args)
        //    .UseStartup(assemblyName);
        //}

    }
}
