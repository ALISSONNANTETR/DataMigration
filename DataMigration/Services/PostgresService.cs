using Npgsql;

using DataMigration.Utils;

namespace DataMigration.Services
{
    internal class PostgresService
    {
        GetConnectionString DatabaseConnection = new GetConnectionString();

        public void PgImport(string tableName, string[] columns)
        {
            string postgreSqlConnString = DatabaseConnection.databaseConnection("Postgres");


            // Connect to PostgreSQL
            using var pgConn = new NpgsqlConnection(postgreSqlConnString);
            try
            {
                pgConn.Open();
                Console.WriteLine("Connected to PostgreSQL.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to PostgreSQL: {ex.Message}");
                return;
            }

            ////truncate table before import
            //new NpgsqlCommand($"TRUNCATE TABLE {tableName};", pgConn).ExecuteNonQuery();
            //Console.WriteLine($"Table {tableName} truncated successfully.");

            //Prepare COPY command for PostgreSQL
            using var importer = pgConn.BeginBinaryImport($"COPY {tableName} ({string.Join(", ", columns)}) FROM STDIN (FORMAT BINARY)");

            //Migrate data from SQL Server to PostgreSQL
            //while (reader.Read())
            //{
            //    importer.StartRow();
            //    for (int i = 0; i < columns.Length; i++)
            //    {
            //        importer.Write(reader.GetValue(i)); // Write each column value
            //    }
            //}

            //importer.Complete();
            Console.WriteLine("Data migration completed successfully.");
        }

        public void PgExport(string tableName, string columns)
        {

        }
        
    }
}
