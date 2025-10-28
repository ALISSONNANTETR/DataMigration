//using System;
//using System.Data.SqlClient;
//using Npgsql;
//using Microsoft.Extensions.Configuration;

//// Connection strings for SQL Server and PostgreSQL
//string sqlServerConnString = ;


//// Define the table and columns to migrate
//var tableName = "GDIC";
//var columns = new[] { "tabela", "coluna", "descricao" }; // specify your columns here

//// Connect to SQL Server
//using var sqlConn = new SqlConnection(sqlServerConnString);
//sqlConn.Open();
//Console.WriteLine("Connected to SQL Server.");

//// Read data from SQL Server
//var query = $"SELECT {string.Join(", ", columns)} FROM {tableName}";
//using var sqlCmd = new SqlCommand(query, sqlConn);
//using var reader = sqlCmd.ExecuteReader();

//// Connect to PostgreSQL
//using var pgConn = new NpgsqlConnection(postgreSqlConnString);
//pgConn.Open();
//Console.WriteLine("Connected to PostgreSQL.");

//// Prepare COPY command for PostgreSQL
//using var importer = pgConn.BeginBinaryImport($"COPY {tableName} ({string.Join(", ", columns)}) FROM STDIN (FORMAT BINARY)");

//// Migrate data from SQL Server to PostgreSQL
//while (reader.Read())
//{
//    importer.StartRow();
//    for (int i = 0; i < columns.Length; i++)
//    {
//        importer.Write(reader.GetValue(i)); // Write each column value
//    }
//}

//importer.Complete();
//Console.WriteLine("Data migration completed successfully.");


using DataMigration.Services;

SqlServerService sqlServerService = new SqlServerService();
sqlServerService.SqlServerExport();