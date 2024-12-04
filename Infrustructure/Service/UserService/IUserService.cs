namespace Service.UserService;
using Model;

public interface IUserService
{
    public void AddUser(Users user, string tableName);
    public void DeleteUser(int id);
    public List<string> GetUserById(int id);
    public void UpdateUser(Users user, string tableName);
}