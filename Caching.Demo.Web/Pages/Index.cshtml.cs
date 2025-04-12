using Caching.Demo.Repository.Entities;
using Caching.Demo.Repository.Interfaces;
using Caching.Demo.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Caching.Demo.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductsManager productsManager;

        [BindProperty]
        public IEnumerable<Product> Products { get; set; } = [];

        public IndexModel(ILogger<IndexModel> logger, IProductsManager productsRepository)
        {
            _logger = logger;
            this.productsManager = productsRepository;
        }

        public async Task OnGet()
        {
            this.Products = await productsManager.GetAllProductsAsync();
        }
    }
}
