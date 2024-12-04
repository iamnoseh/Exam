namespace Service;
using System.Security.Cryptography.X509Certificates;
using Infrustructure.Common;
using Npgsql;



public static class NpgsqlService
{
    public static void CreateDatabase(string databaseName)
    {
        try
        {
            string connectionString ="Server = localhost; Port = 5432; Database = postgres; Username = postgres; Password = 12345; ";
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(connectionString);
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = $"Create database {databaseName}; ";
           int res = command.ExecuteNonQuery();
           if (res != 0)
           {
                System.Console.WriteLine($"Database bo nomi {databaseName} sokhta shud!");
           }
           else
           {
            System.Console.WriteLine("Error! Database sokhta nashud!");
           }

        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            throw;
        }
    }
    public static void CreateTable(string databaseName,string tablename,string[] collumns)
    {
          try
          {
              string connectionString =$"Server = localhost; Port = 5432; Database = {databaseName} ; Username = postgres; Password = 12345; ";
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(connectionString);
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            string column = string.Join(", ", collumns); 
            string createTableQuery = $@"
            CREATE TABLE IF NOT EXISTS {tablename} 
                                        (
                                        {column}
                                         );";
            int res = command.ExecuteNonQuery();
            if(res != 0)
            {
                System.Console.WriteLine($"Table bo nomi {tablename} sokhta shud !");
            }
            else
            {
                System.Console.WriteLine("Error! Khatogi dar sokhtani Table");
            }

          }
          catch (NpgsqlException e)
          {
            System.Console.WriteLine(e.Message);
            throw;
          }
          catch (Exception e)
          {
            System.Console.WriteLine(e.Message);
            throw;
          }
    }
}

