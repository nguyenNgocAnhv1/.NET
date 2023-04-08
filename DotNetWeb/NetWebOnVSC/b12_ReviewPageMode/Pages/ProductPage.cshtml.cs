using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace b12_ReviewPageMode.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly ILogger<ProductPageModel> _logger;
        public readonly ProductService productService;

        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService _productService)
        {
            _logger = logger;
            productService = _productService;
        }
        public Product product { get; set; }
        public void OnGet(int? id)
        {
            if (Request.RouteValues["id"] != null)
            {
                ViewData["Title"] = "San pham co id = " + id.Value;
                product = productService.Find(id.Value);

            }
            else
            {
                ViewData["Title"] = "Danh sach san pham ";
            }
        }
        // /product/{id:int?}?handle=lastproduct
        public IActionResult OnGetLastProduct()
        {
            ViewData["Title"] = "San pham cuoi";
            product = productService.AllProducts().LastOrDefault();
            if (product != null)
            {
                return Page();
            }
            else
            {
                return this.Content("Khong thay san pham");
            }
        }
        public IActionResult OnGetRemoveAll()
        {
            productService.AllProducts().Clear();
            return RedirectToPage("ProductPage");
        }
        public IActionResult OnGetLoad()
        {
            productService.LoadProducts();

            return RedirectToPage("ProductPage");
        }
        public IActionResult OnPostDelete(int? id)
        {
            System.Console.WriteLine("===========");
            if (id != null)
            {
                System.Console.WriteLine("===========");
                Console.WriteLine(id);
                var product = productService.Find(id.Value);
                if (product != null)
                {
                    productService.AllProducts().Remove(product);
                };
            }
            // return this.Content("lll");
            return this.RedirectToPage("ProductPage", new { id = string.Empty });
        }
    }
}
