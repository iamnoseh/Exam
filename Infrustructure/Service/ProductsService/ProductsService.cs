namespace Service.UserService;
using Infrustructure.Common;
using Model;
using Npgsql;

public class ProductsService: IProductsService
{
    public void AddProducts(Products products, string TableName)
    {
        public void AddProducts(Products products, string TableName)
        {
        
            using (var connection = NpgsqlHelper.CreateConnection(connectionString))
            {
                var command = new NpgsqlCommand($"INSERT INTO {TableName} (ProductId,Name,Description,Price,Stock) " +
                                                $"values(@ProductId,@Name,@Description,@Price,@Stock)",connection);
                command.Parameters.AddWithValue("ProductId", products.ProductId);
                command.Parameters.AddWithValue("Name", products.Name);
                command.Parameters.AddWithValue("Description", products.Description);
                command.Parameters.AddWithValue("Price", products.Price);
                command.Parameters.AddWithValue("Stock", products.Stock);
            }
        }
    }

    public void DeleteProducts(int id)
    {
        using (var connection = NpgsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"DELETE FROM Products WHERE ProductId = @ProductId", connection);
            command.Parameters.AddWithValue("ProductId", id);
            command.ExecuteNonQuery();
        }
    }

    public List<Products> GetProductsById(int id)
    {
        List<Products> products = new List<Products>();
        using (var connection = NpgsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"SELECT * FROM {tableName} WHERE id = @id", connection);
            command.Parameters.AddWithValue("id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Products products = new Products()
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = Convert.ToDecimal(reader.GetString(3)),
                            Stock = Convert.ToInt32(reader.GetString(4)),
                        };
                        products.Add(products);
                    }
                }
            }
        }
        return products;
    }

    public void UpdateProducts(Products products, string TableName)
    {
        using (var connection = NpgsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"INSERT INTO {TableName} (ProductId,Name,Description,Price,Stock) " +
                                            $"values(@ProductId,@Name,@Description,@Price,@Stock)",connection);
            command.Parameters.AddWithValue("ProductId", products.ProductId);
            command.Parameters.AddWithValue("Name", products.Name);
            command.Parameters.AddWithValue("Description", products.Description);
            command.Parameters.AddWithValue("Price", products.Price);
            command.Parameters.AddWithValue("Stock", products.Stock);
            
            command.ExecuteNonQuery();
        }
    }
}