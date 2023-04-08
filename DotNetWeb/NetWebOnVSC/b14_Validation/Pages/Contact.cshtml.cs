using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace b14_Validation.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public ContactModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [BindProperty]
        public CustomerInfor customerInfor { get; set; }
        [BindProperty]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Chọn file upload")]
        [DisplayName("File Upload")]
        [CheckFileExtention(Extensions = "jpg,png,gif")]
        public IFormFile FileUpLoader { get; set; }
        public string ThongBao { set; get; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                ThongBao = "Dữ liệu gửi đến phù hợp";
                if (FileUpLoader != null)
                {
                    
                        var filePart = Path.Combine(_environment.WebRootPath, "Upload", FileUpLoader.FileName);
                        using var filestream = new FileStream(filePart, FileMode.Create);
                        FileUpLoader.CopyTo(filestream);
                    
                }
            }
            else
            {
                ThongBao = "Dữ liệu gửi đến không phù hợp";
            }
        }
    }
}
