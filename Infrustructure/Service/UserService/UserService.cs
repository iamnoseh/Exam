namespace Service.UserService;
using Infrustructure.Common;
using Model;
using Npgsql;

public class UserService(string connectionString) : IUserService
{
    public void AddUser(Users user, string tableName)
    {
        
        using (var connection = NpgsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"INSERT INTO {tableName} (UserId,Name,Email,PasswordHash,Role,CreatedAt) " +
                                            $"values(@UserId,@Name,@Email,@PasswordHash,@Role,@CreatedAt)",connection);
            command.Parameters.AddWithValue("UserId", user.UserId);
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

    public List<User> GetUsersById(int id, string tableName)
    {
        List<User> users = new List<User>();
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
                        User user = new User()
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

    public void UpdateUsers(User user, string tableName)
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