using ModelContextProtocol.Server;
using Label.Mcp.Product.Services;

namespace Label.Mcp.Product.McpTools;

[McpServerToolType]
public class ProductTools
{
    private readonly IProductRepository _repository;

    public ProductTools(IProductRepository repository)
    {
        _repository = repository;
    }

    [McpServerTool]
    public async Task<object?> GetProduct(string itemNumber)
    {
        return await _repository.GetProductAsync(itemNumber);
    }

    [McpServerTool]
    public async Task<object?> GetSupplementFacts(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.SupplementFacts;
    }

    [McpServerTool]
    public async Task<object?> GetIngredients(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        if (product == null)
            return null;

        return new
        {
            SupplementFacts = product.SupplementFacts,
            OtherIngredients = product.OtherIngredients
        };
    }

    [McpServerTool]
    public async Task<string?> GetAllergens(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.Allergens;
    }

    [McpServerTool]
    public async Task<string?> GetDirections(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.Directions;
    }

    [McpServerTool]
    public async Task<string?> GetWarnings(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.Warnings;
    }

    [McpServerTool]
    public async Task<string?> GetCaution(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.Caution;
    }

    [McpServerTool]
    public async Task<string?> GetDisclaimers(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.Disclaimers;
    }

    [McpServerTool]
    public async Task<string?> GetTrademarkRequirements(string itemNumber)
    {
        var product = await _repository.GetProductAsync(itemNumber);

        return product?.TrademarkRequirements;
    }

    [McpServerTool]
    public async Task<List<object>> ListProducts()
    {
        var products = await _repository.GetAllProductsAsync();

        return products.Cast<object>().ToList();
    }

    [McpServerTool]
    public async Task<object?> FindProductByName(string name)
    {
        return await _repository.FindByNameAsync(name);
    }

    [McpServerTool]
    public async Task<object> SearchProducts(string searchTerm)
    {
        var products = await _repository.GetAllProductsAsync();

        return products
            .Where(p =>
                p.ItemName.Contains(
                    searchTerm,
                    StringComparison.OrdinalIgnoreCase))
            .Select(p => new
            {
                p.ItemNumber,
                p.ItemName
            });
    }
}