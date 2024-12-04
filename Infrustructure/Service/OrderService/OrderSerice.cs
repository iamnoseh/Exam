namespace Service.OrderService;
using Npgsql;
using Model;
using Service.OrderService;

public class OrderService : IOrderService
{
    public void AddOrder(Orders order, string tableName)
    {
        try
        {
            
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

    public void DeleteOrder(int id, string tableName)
    {
        throw new NotImplementedException();
    }

    public void GetOrderById(int id, string tableName)
    {
        throw new NotImplementedException();
    }

    public void UpdateOrder(Orders order, string tableName)
    {
        throw new NotImplementedException();
    }
}