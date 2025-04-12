using Caching.Demo.Repository.Entities;
using Caching.Demo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caching.Demo.Repository.Context
{
    public class ApplicationDbContext: DbContext, IApplicationContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
    }
}
