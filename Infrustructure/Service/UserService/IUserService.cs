namespace Service.UserService;
using Model;

public interface IUserService
{
    void AddUser(User user, string TableName);
    void DeleteUser(int id);
    List<string> GetUserById(int id);
    void UpdateUser(User user, string TableName);
}