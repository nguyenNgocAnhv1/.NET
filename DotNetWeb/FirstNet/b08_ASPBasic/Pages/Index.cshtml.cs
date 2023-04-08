using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace b08_ASPBasic.Pages;

public class IndexModel : PageModel
{
    public string text{get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        this.text = "Xin chao tu model";
    }
}
