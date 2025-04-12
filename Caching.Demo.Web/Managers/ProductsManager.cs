using Caching.Demo.Repository.Entities;
using Caching.Demo.Repository.Interfaces;
using Caching.Demo.Web.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.Demo.Web.Managers
{
    public class ProductsManager : IProductsManager
    {
        private readonly IMemoryCache cache;
        private readonly IProductsRepository productsRepository;
        private const string ProductsCacheKey = "ProductsCacheKey";

        public ProductsManager(IMemoryCache cache, IProductsRepository productsRepository)
        {
            this.cache = cache;
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            IEnumerable<Product> products = [];

            if (!cache.TryGetValue(ProductsCacheKey, out products!))
            {
                products = await productsRepository.GetAllAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                cache.Set(ProductsCacheKey, products, cacheEntryOptions);
            }

            return products;
        }


    }
}
