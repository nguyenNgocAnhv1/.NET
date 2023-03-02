public class ProductName
{
    public List<string> names { get; set; }
    public ProductName()
    {
        names = new List<string>()
        {
            "Iphone 7",
            "Iphone 8",
            "Iphone 9",
        };
    }
    public List<string> GetNames() => names;

}