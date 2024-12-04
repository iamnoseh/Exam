namespace Service.Categories;
using Infrustructure.Common;
using Model;
using Npgsql;
using System.Collections.Generic;

public class CategoriesService(string connectionString) : ICategoriesService
{
    public void AddCategory(Categories category, string tableName)
    {
        using (var connection = NpgsqlHelper.CreateConnection(connectionString))
        {
            var command = new NpgsqlCommand($"INSERT INTO {tableName} (CategoryId,Name,Description) " +
                                            $"values(@CategoryId,@Name,@Description)",connection);
            command.Parameters.AddWithValue("CategoryId", Categories.CategoryId);
            command.Parameters.AddWithValue("Name", Categories.Name);
            command.Parameters.AddWithValue("Description", Categories.Description);
            
        }
    }
}