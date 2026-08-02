namespace Label.Mcp.Product.Models;

public class Product
{
    public string ItemNumber { get; set; } = "";
    public string ItemName { get; set; } = "";
    public string UPCCode { get; set; } = "";
    public string Tagline { get; set; } = "";

    public string Quantity { get; set; } = "";
    public string ServingSize { get; set; } = "";

    public int ServingsPerContainer { get; set; }

    public List<SupplementFact> SupplementFacts { get; set; } = [];

    public List<string> OtherIngredients { get; set; } = [];

    public string Allergens { get; set; } = "";

    public string Directions { get; set; } = "";

    public string Caution { get; set; } = "";

    public string Disclaimers { get; set; } = "";

    public string TrademarkRequirements { get; set; } = "";

    public string Warnings { get; set; } = "";
}