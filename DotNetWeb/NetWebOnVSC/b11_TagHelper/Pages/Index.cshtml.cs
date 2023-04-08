using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace b11_TagHelper.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [DisplayName("Ten nguoi dung")]
    public string UserName { set; get; } = "NA";
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
