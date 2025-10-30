using Npgsql;
using System.Data.SqlClient;

using DataMigration.Utils;
using System.Data;

namespace DataMigration.Services
{
    internal class SqlServerService
    {
        GetConnectionString DatabaseConnection = new GetConnectionString();
        public void SqlServerImport()
        {

        }

        public void SqlServerExport(string tableName, string[] columns)
        {
            string sqlServerConnString = DatabaseConnection.databaseConnection("SqlServer");
            

            // Define the table and columns to migrate
            //var tableName = "GDIC";
            //var columns = new[] { "tabela", "coluna", "descricao" }; // specify your columns here

            // Connect to SQL Server
            using var sqlConn = new SqlConnection(sqlServerConnString);
            try
            {
                sqlConn.Open();
                Console.WriteLine("Connected to SQL Server.");
            }catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to SQL Server: {ex.Message}");
                return;
            }

            // Read data from SQL Server
            var query = $"SELECT {string.Join(", ", columns)} FROM {tableName}";
            using var sqlCmd = new SqlCommand(query, sqlConn);
            using var reader = sqlCmd.ExecuteReader();


        }

        public void SqlServerColumns(string table)
        {
            string sqlServerConnString = DatabaseConnection.databaseConnection("SqlServer");

            // Connect to SQL Server
            using var sqlConn = new SqlConnection(sqlServerConnString);
            try
            {
                sqlConn.Open();
                Console.WriteLine("Connected to SQL Server.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to SQL Server: {ex.Message}");
                return;
            }

            // Read data from SQL Server
            var query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table}'";

            using var sqlCmd = new SqlCommand(query, sqlConn);
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}",reader[0]));
                }
            }
            Console.WriteLine("\n");

        }

    }
}
