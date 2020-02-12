//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.WebApplication
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Entry point of our WebApplication
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method of the app
        /// </summary>
        /// <param name="args">App boot args</param>
        public static void Main(string[] args)
        {
            // ASP.Net structure
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// ASP.Net Structure initialization
        /// </summary>
        /// <param name="args">App boot args</param>
        /// <returns>A program initialization abstraction.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
