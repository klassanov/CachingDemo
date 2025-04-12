using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caching.Demo.Repository.Entities;

namespace Caching.Demo.Repository.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
