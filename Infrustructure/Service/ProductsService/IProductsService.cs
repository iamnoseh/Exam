using Model;

namespace Service.ProductService;

public interface IProductsService
{
    void AddProducts (Products products, string TableName);
    void DeleteProducts (int id);
    List<string> GetProductsById (int id);
    void UpdateProducts (Products products, string TableName);
}