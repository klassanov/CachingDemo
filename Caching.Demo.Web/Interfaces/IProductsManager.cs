using Caching.Demo.Repository.Entities;

namespace Caching.Demo.Web.Interfaces
{
    public interface IProductsManager
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
