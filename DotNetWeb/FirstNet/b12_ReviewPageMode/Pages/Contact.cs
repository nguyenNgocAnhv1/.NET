using Microsoft.AspNetCore.Mvc.RazorPages;

public class Contact : PageModel
{
    public string Name { get; set; } = "Hello from contact cs";
    public Contact()
    {
        System.Console.WriteLine("Init contact ... ");
    }

}