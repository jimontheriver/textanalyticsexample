using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;


namespace TextAnalyticsExamples
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";
            //Determines the working environment as IHostingEnvironment is unavailable in a console app
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (isDevelopment) //only add secrets in development
            {
                builder.AddUserSecrets(Assembly.GetExecutingAssembly());
            }

            Configuration = builder.Build();

            var liteBot = new LiteBot(Configuration);
           
            do
            {
                string command = ShowMenu();
                if (command.ToLowerInvariant() == "q")
                {
                    return;
                }

                liteBot.ProcessCommandAsync(command).Wait();
            } while (true);
        }

        public static string ShowMenu()
        {
            Console.WriteLine("Type the command");
            Console.WriteLine("Type q to quit.");
            Console.WriteLine();
            return Console.ReadLine();
        }
    }
}
