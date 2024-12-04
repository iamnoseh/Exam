namespace Service.UserService;
using Infrustructure.Common;
using Model;
using Npgsql;
using System.Collections.Generic;
public class UserService(string connectionString) : IUserService
{
    public void AddUser(Users user, string tableName)
    {
        using (var connection = NgpsqlHelper.CreateConnection(connectionString))
        {
            var command = new NgpsqlCommand($"INSERT INTO {tableName} (UserId,Name,Email,PasswordHash,Role,CreatedAt) " +
                                            $"values(@UserId,@Name,@Email,@PasswordHash,@Role,@CreatedAt)",connection);
            command.parseArgs.AddWithValue("UserId", user.UserId);
            command.Parameters.AddWithValue("Name", user.Name);
            command.Parameters.AddWithValue("Email", user.Email);
            command.Parameters.AddWithValue("PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("Role", user.Role);
            command.Parameters.AddWithValue("CreatedAt", user.CreatedAt);
        }
    }

    public void DeleteUser(int id,string tableName)
    {
        using (var connection = NgpsqlHelper.CreateConnection(connectionString))
        {
            var command = new NgpsqlCommand($"DELETE FROM Users WHERE UserId = @UserId", connection);
            command.Parameters.AddWithValue("UserId", id);
            command.ExecuteNonQuery();
        }
    }

    public List<Users> GetUsersById(int id, string tableName)
    {
        List<Users> users = new List<Users>();
        using (var connection = NgpsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"SELECT * FROM {tableName} WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Users user = new Users()
                        {
                            UserId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            PasswordHash = reader.GetString(3),
                            Role = reader.GetString(4),
                            CreatedAt = reader.GetDateTime(5)
                        };
                        users.Add(user);
                    }
                }
            }
        }
        return users;
    }

    public void UpdateUsers(Users user, string tableName)
    {
        using (var connection = NgpsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"UPDATE {tableName} SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash, Role = @Role WHERE UserId = @UserId", connection);
            command.Parameters.AddWithValue("UserId", user.UserId);
            command.Parameters.AddWithValue("Name", user.Name);
            command.Parameters.AddWithValue("Email", user.Email);
            command.Parameters.AddWithValue("PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("Role", user.Role);
            
            command.ExecuteNonQuery();
        }
    }
}

file static class SqlCommands
{
    public const string ConnectionString =
        "Server = localhost; Port = 5432; Database = postgres; username = postgres; password=LMard1909;";

    // public const string CreateDatabase = $"Create database {databaseName};";
    public const string DropDatabase = "Drop database @databaseName with(force);";
    public const string DropTable = "Drop table @tableName;";
}