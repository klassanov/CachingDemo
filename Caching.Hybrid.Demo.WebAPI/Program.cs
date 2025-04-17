using Microsoft.Extensions.Caching.Hybrid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Hybrid cache configuration
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

builder.Services.AddHybridCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Minimal APIs configuration
app.MapGet("/", () =>  "Hello world!" );

app.MapGet("/products", async (HybridCache cache) =>
{
    var products = 
    await cache.GetOrCreateAsync(
        key: "products",
        factory: async (cancellationToken) => 
        {
            return await Task.FromResult<List<string>>(["product-1", "product-2", "product-3"]);
        });

    return Results.Ok(products);
});

//app.MapControllers();

app.Run();
