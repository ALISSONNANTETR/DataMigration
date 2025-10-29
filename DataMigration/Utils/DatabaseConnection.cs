using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigration.Utils
{
    internal class DatabaseConnection
    {
        public string databaseConnection(string sgbd)
        {
            // Build configuration to read from appsettings.json
            var config = new ConfigurationBuilder()
                            .SetBasePath(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../")))
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();

            // Connection strings for SQL Server and PostgreSQL
            return config.GetConnectionString($"{sgbd}");
        }
    }
}
