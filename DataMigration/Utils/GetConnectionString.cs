using Microsoft.Extensions.Configuration;

namespace DataMigration.Utils
{
    internal class GetConnectionString
    {
        public string databaseConnection(string sgbd)
        {
            // Build configuration to read from appsettings.json
            var config = new ConfigurationBuilder()
                            .SetBasePath(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../")))
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

            // Connection strings for SQL Server and PostgreSQL
            return config.GetConnectionString(sgbd);
        }
    }
}
