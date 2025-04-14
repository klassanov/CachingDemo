using Caching.Demo.Repository.Entities;

namespace Caching.Demo.Web.GetProductsFeature
{
    public interface IProductsManager
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        //void InvalidateCacheKey();
    }
}
