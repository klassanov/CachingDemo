using Caching.Demo.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caching.Demo.Repository.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
    }
}
