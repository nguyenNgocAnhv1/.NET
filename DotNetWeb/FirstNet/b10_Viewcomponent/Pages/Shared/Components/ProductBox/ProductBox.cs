using Microsoft.AspNetCore.Mvc;

namespace XTLAB
{
    // string (IViewComponentResult) Invoke (Object M)
    // 3 way to use components (theory)
    //
    public class ProductBox : ViewComponent
    {
        ProductListService productsService;
        public ProductBox(ProductListService _products)
        {
            productsService = _products;
        }

        public IViewComponentResult Invoke(bool xapxeptang = false)
        {



            List<Product> _product = null;
            if (xapxeptang)
            {
                _product = productsService.list.OrderBy(p => p.Price).ToList();
            }
            else
            {
                _product = productsService.list.OrderByDescending(p => p.Price).ToList();
            }
            return View<List<Product>>(_product);  //
        }
    }
}