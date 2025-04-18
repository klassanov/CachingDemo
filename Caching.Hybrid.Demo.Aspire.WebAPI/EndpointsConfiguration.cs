using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Hybrid.Demo.Aspire.WebAPI
{
    public static class EndpointsConfiguration
    {
        private const string productsKey = "products";

        public static WebApplication ConfigureMinimalAPIs(this WebApplication app)
        {
            app.MapGet("/", () => "Hello world!");

            app.MapGet("/products", async (HybridCache cache) =>
            {
                var products =
                await cache.GetOrCreateAsync(
                    key: productsKey,
                    factory: ProductsFactory);

                return Results.Ok(products);
            });

            app.MapGet("/localcache", async (IMemoryCache memoryCache) =>
            {
                var localCache = memoryCache as MemoryCache;
                return Results.Ok(value: localCache!.Keys);
            });

            app.MapPost("/invalidate/products", async (HybridCache cache) =>
            {
                await cache.RemoveAsync(key: productsKey);
            });

            return app;
        }

        private static ValueTask<List<string>> ProductsFactory(CancellationToken cancellationToken)
            => ValueTask.FromResult<List<string>>(["product-1", "product-2", "product-3"]);
        
    }
}
