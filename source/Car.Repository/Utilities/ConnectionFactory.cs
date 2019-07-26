using System.IO;
using Microsoft.Extensions.Configuration;
namespace Car.Repository.Utilities
{
    public class ConnectionFactory
    {
        public static string GetConnection()
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return build.GetConnectionString("DefaultConnection");
        }
    }
}