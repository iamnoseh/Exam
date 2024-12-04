namespace Service.OrderService;
using Npgsql;
using Model;
public interface IOrderService
{
    public void AddOrder(Orders order,string tableName);
    public void GetOrderById(int id,string tableName);
    public void UpdateOrder(Orders order,string tableName);
    public void DeleteOrder(int id,string tableName);
} 