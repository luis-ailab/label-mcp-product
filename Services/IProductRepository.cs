using ProductModel = Label.Mcp.Product.Models.Product;

namespace Label.Mcp.Product.Services;

public interface IProductRepository
{
    Task<ProductModel?> GetProductAsync(string itemNumber);

    Task<List<ProductModel>> GetAllProductsAsync();

    Task<ProductModel?> FindByNameAsync(string name);
}