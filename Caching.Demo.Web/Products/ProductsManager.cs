using Caching.Demo.Repository.Entities;
using Caching.Demo.Repository.Interfaces;
using Caching.Demo.Web.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Demo.Web.Products
{
    public class ProductsManager : IProductsManager
    {
        private readonly IMemoryCache cache;
        private readonly IProductsRepository productsRepository;
        private readonly ILogger<ProductsManager> logger;
        private const string ProductsCacheKey = "ProductsCacheKey";

        public ProductsManager(IMemoryCache cache, IProductsRepository productsRepository, ILogger<ProductsManager> logger)
        {
            this.cache = cache;
            this.productsRepository = productsRepository;
            this.logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            IEnumerable<Product> products = [];

            if (!cache.TryGetValue(ProductsCacheKey, out products!))
            {
                products = await productsRepository.GetAllAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                cache.Set(ProductsCacheKey, products, cacheEntryOptions);

                logger.LogInformation("Cache miss for products. Data fetched from repository and cached.");
            }

            else
            {
                logger.LogInformation("Cache hit for products.");
            }

            return products;
        }


    }
}
