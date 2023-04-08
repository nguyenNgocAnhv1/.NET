public class ProductService
{
    private List<Product> products = new List<Product>();
    public ProductService()
    {
        LoadProducts();
    }
    public Product Find(int id)
    {
        var qr = from p in products
                 where p.Id == id
                 select p;
        return qr.FirstOrDefault();
    }
    public void LoadProducts()
    {
        products.Clear();
        products.Add(new Product()
        {
            Id = 1,
            Name = "Iphone",
            Price = 999,
            Description = "Dien thoai i phone"
        });
        products.Add(new Product()
        {
            Id = 2,
            Name = "Samsung",
            Price = 700,
            Description = "Dien thoai han quoc "
        });
        products.Add(new Product()
        {
            Id = 3,
            Name = "Xiaomi",
            Price = 555,
            Description = "Gia re, cau hinh ngon "
        });
    }
    public List<Product> AllProducts() => products;
}