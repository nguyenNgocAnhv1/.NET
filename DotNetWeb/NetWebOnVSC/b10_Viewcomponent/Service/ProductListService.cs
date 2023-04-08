namespace XTLAB
{
    public class ProductListService
    {
        public List<Product> list { set; get; } = new List<Product>(){
            new Product(){Name = "Iphone",Description = "Apple phone",Price = 900},
            new Product(){Name = "Samsung",Description = "Sam fan",Price = 7000},
            new Product(){Name = "Xiaomi",Description = "Mi xao rau rua",Price = 300},
            };
    }
}