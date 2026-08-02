using Label.Mcp.Product.McpTools;
using Label.Mcp.Product.Models;
using Label.Mcp.Product.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductRepository,
                              JsonProductRepository>();

builder.Services.AddMcpServer()
                .WithHttpTransport()
                .WithTools<ProductTools>();

var app = builder.Build();

app.MapMcp("/mcp");

app.MapGet("/health", () => "OK");

app.Run();