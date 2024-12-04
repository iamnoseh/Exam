namespace Service.Categories;

public interface ICategoriesService
{
    public void AddCategory(ICategoriesService categoryService, string tableName);
    public void DeleteCategory(int id);
    public List<string> GetCategoryById(int id);
    public void UpdateCategory(ICategoriesService categoryService, string tableName);
}