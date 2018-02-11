using BLL.Abstractions.Services;
using shop.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _productService.GetProducts(cancellationToken);

            var model = new ProductsViewModel { Products = result.Value };

            return View(model);
        }
    }
}