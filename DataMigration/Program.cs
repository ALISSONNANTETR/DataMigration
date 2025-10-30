//using System;
//using System.Data.SqlClient;
//using Npgsql;

//using DataMigration.Utils;
//using Microsoft.Extensions.Configuration;


//GetConnectionString DatabaseConnection = new GetConnectionString();

////Connection strings for SQL Server and PostgreSQL
//string sqlServerConnString = DatabaseConnection.databaseConnection("SqlServer");
//string postgreSqlConnString = DatabaseConnection.databaseConnection("Postgres");

//// Define the table and columns to migrate
//var tableName = "gconssql";
//var columns = new[] { "codcoligada", "aplicacao", "codsentenca", "titulo", "sentenca" }; // specify your columns here


////Connect to SQL Server
//using var sqlConn = new SqlConnection(sqlServerConnString);
//sqlConn.Open();
//Console.WriteLine("Connected to SQL Server.");

////Read data from SQL Server
//var query = $"SELECT {string.Join(", ", columns)} FROM {tableName}";
//using var sqlCmd = new SqlCommand(query, sqlConn);
//using var reader = sqlCmd.ExecuteReader();

////Connect to PostgreSQL
//using var pgConn = new NpgsqlConnection(postgreSqlConnString);
//pgConn.Open();
//Console.WriteLine("Connected to PostgreSQL.");

////truncate table before import
//new NpgsqlCommand($"TRUNCATE TABLE {tableName};", pgConn).ExecuteNonQuery();

////Prepare COPY command for PostgreSQL
//using var importer = pgConn.BeginBinaryImport($"COPY {tableName} ({string.Join(", ", columns)}) FROM STDIN (FORMAT BINARY)");

////Migrate data from SQL Server to PostgreSQL
//while (reader.Read())
//{
//    importer.StartRow();
//for (int i = 0; i < columns.Length; i++)
//{
//    importer.Write(reader.GetValue(i)); // Write each column value
//}
//}

//importer.Complete();
//Console.WriteLine("Data migration completed successfully.");


using DataMigration.Services;

SqlServerService sqlServerService = new SqlServerService();
PostgresService postgresService = new PostgresService();

var tableName = "GDIC";
var columns = new[] { "tabela", "coluna", "descricao" }; // specify your columns here

sqlServerService.SqlServerExport(tableName, columns);
postgresService.PgImport(tableName, columns);


//Console.WriteLine("Enter the table name to migrate: ");
//// Define the table and columns to migrate
//var tableName = Console.ReadLine();
//var columns = new[] { "" }; // specify your columns here

//Console.WriteLine($"Migrate table {tableName}?");
//sqlServerService.SqlServerColumns(tableName);

//Console.WriteLine("Enter the column name to migrate (or press Enter to finish): ");
//do
//{
//    columns.Append(Console.ReadLine() + ",");
//} while (Console.ReadLine() != "");

//foreach (var column in columns)
//{ 
//    Console.WriteLine(column);
//}