namespace Service.UserService;
using Model;

public interface IUserService
{
    void AddUser(Users user, string tableName);
    void DeleteUser(int id);
    List<string> GetUserById(int id);
    void UpdateUser(Users user, string tableName);
}