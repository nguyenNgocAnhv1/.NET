using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace b13_ModelBinding.Pages;

public class PrivacyModel : PageModel
{
    // public UserPrivacy x = new UserPrivacy(){UserId=11,UserName="",Email=""};
    [BindProperty]
    public UserPrivacy up{get; set; } 
    1       
    private readonly ILogger<PrivacyModel> _logger;
    // dung binh thuong
    // [BindProperty(SupportsGet = true)]
    // [DisplayName("Id của bạn")]
    // [Range(10,20,ErrorMessage = "Nhap sai")]
    // public int UserId { get; set; }
    // [BindProperty]
    // [DisplayName("Email")]
    // [EmailAddress(ErrorMessage ="Email sai dinh dang")]
    // public string Email { get; set; }
    // [BindProperty]
    // [DisplayName("Ten cua ban")]
    // public string UserName { get; set; }
    // su dung object
   
    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    // specify the get valut by: [FromQuery], [FromRoute]...
    // specify the name of the data [FromQuery(Name = "sanpham)]
    // specify the properties for the object [Bind("Name","Price")]
    public void OnGet([FromQuery(Name = "maso")]int? id, [Bind("Name","Price")] Product p)
    {
        //      var data =this.Request.RouteValues["id"];
        //      var data = this.Request.Query["id"];
        //      var data = this.Request.RouteValues["id"];
        //      var data = this.Request.Headers["id"]; 
        System.Console.WriteLine("Route Value");
        var data = this.Request.RouteValues["id"]; 
        if (id != null)
        {
            System.Console.WriteLine(data.ToString());
        }
        System.Console.WriteLine("Query");
        var data1 = this.Request.Query["id"];
        if (!string.IsNullOrEmpty(data1))
        {
            System.Console.WriteLine(data1);
        }
        var data2 = this.Request.Headers["User-Agent"];
        System.Console.WriteLine("Header");
        if (!string.IsNullOrEmpty(data2))
        {
            System.Console.WriteLine(data2);
        }
        System.Console.WriteLine("Parameters Bindings");
        System.Console.WriteLine(id);
        System.Console.WriteLine("=== Product ===");
        System.Console.WriteLine(p.Name);
        System.Console.WriteLine(p.Price);
    }
    public void OnPost(){
        // System.Console.WriteLine(this.x.UserName);
        // System.Console.WriteLine(this.x.Email);
        // System.Console.WriteLine(this.x.UserId);


    }
}

