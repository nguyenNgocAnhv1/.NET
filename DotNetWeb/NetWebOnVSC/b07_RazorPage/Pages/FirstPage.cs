using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModel : PageModel
{
    public string Title { get; set; } = "Xin chao tu model";
     public void OnGet(){
        System.Console.WriteLine("Run OnGet Method");

    }  
    // Get, Url?handled=xyz 
    // => thuc thi khi url chi handler la xyz
    public void OnGetXyz(){
        System.Console.WriteLine("Run OnGet Method by handler xyz");
    }   
}