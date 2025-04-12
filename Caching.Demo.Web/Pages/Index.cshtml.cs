using Caching.Demo.Repository.Entities;
using Caching.Demo.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Caching.Demo.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductsRepository productsRepository;

        [BindProperty]
        public IEnumerable<Product> Products { get; set; } = [];

        public IndexModel(ILogger<IndexModel> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            this.productsRepository = productsRepository;
        }

        public async Task OnGet()
        {
            this.Products = await productsRepository.GetAllAsync();
        }
    }
}
