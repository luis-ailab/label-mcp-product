using System.Text.Json;
using ProductModel = Label.Mcp.Product.Models.Product;

namespace Label.Mcp.Product.Services;

public class JsonProductRepository : IProductRepository
{
    private readonly string _dataPath;

    public JsonProductRepository(IWebHostEnvironment env)
    {
        _dataPath = Path.Combine(env.ContentRootPath, "Data");
    }

    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        var products = new List<ProductModel>();

        foreach (var file in Directory.GetFiles(_dataPath, "*.json"))
        {
            var json = await File.ReadAllTextAsync(file);

            var product =
                JsonSerializer.Deserialize<ProductModel>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (product != null)
                products.Add(product);
        }

        return products;
    }

    public async Task<ProductModel?> GetProductAsync(string itemNumber)
    {
        var products = await GetAllProductsAsync();

        return products.FirstOrDefault(p =>
            p.ItemNumber.Equals(itemNumber,
            StringComparison.OrdinalIgnoreCase));
    }

    public async Task<ProductModel?> FindByNameAsync(string name)
    {
        var products = await GetAllProductsAsync();

        return products.FirstOrDefault(p =>
            p.ItemName.Contains(
                name,
                StringComparison.OrdinalIgnoreCase));
    }
}