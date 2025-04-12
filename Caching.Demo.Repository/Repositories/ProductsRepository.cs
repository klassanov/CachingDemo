using Caching.Demo.Repository.Entities;
using Caching.Demo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caching.Demo.Repository.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IApplicationContext context;
        public ProductsRepository(IApplicationContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products
                                .OrderBy(p=>p.Name)
                                .ToListAsync();
        }
    }
}