using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XTLAB;
namespace b10_Viewcomponent.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    // public IActionResult OnGet()
    // {
    //     // PageModel: Partial
    //     // Controller: PartialView
    //     // return Partial("_Message");
    //     return ViewComponent("ProductBox");
    // }
    public IActionResult OnPost()
    {
        var name = this.Request.Form["usename"];
        System.Console.WriteLine(name);
        var message = new MessagePage.Message();
        message.title = "Thong bao";
        message.htmlcontent = "Cam on ban da gui thong tin  " + name;
        message.secondwait = 7;
        message.urlredirect = Url.Page("Privacy");
        return ViewComponent("MessagePage", message);
    }
}
