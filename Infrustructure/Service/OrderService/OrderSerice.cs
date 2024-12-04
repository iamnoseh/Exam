namespace Service.OrderService;
using Npgsql;
using Model;
using Service.OrderService;
using Infrustructure.Common;

public class OrderService : IOrderService
{
    public void AddOrder(Orders order, string tableName)
    {
        try
        {
            string connectionString =$"Server = localhost; Port = 5432; Database = EmployeeDb ; Username = postgres; Password = 12345; ";
            using NpgsqlConnection connection = NpgsqlHelper.CreateConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO {tableName} (OrderId,UserId,Orderdate,Totalamout,Status) " +
                                            $"values(@OrderId,@UserId,@Orderdate,@Totalamout,@Status)",connection);
            command.Parameters.AddWithValue("OrderId",order.OrderId);
            command.Parameters.AddWithValue("UserId",order.UserId);
            command.Parameters.AddWithValue("Orderdate",order.OrderDate);
            command.Parameters.AddWithValue("Status",order.Status);
            int res = command.ExecuteNonQuery();
            if(res != 0)
            {
                System.Console.WriteLine("Insert shud!");
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