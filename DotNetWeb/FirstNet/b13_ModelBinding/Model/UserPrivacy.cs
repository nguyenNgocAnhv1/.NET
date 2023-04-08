using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserPrivacy{
    [BindProperty]
    [DisplayName("Id của bạn")]
    [Range(10,20,ErrorMessage = "Nhap sai")]
    public int UserId { get; set; } 
    [BindProperty]
    [DisplayName("Email")]
    [EmailAddress(ErrorMessage ="Email sai dinh dang")]
    public string Email { get; set; } 
    [BindProperty]
    [DisplayName("Ten cua ban")]
    [DefaultValue("unknown")]
    public string UserName { get; set; } 
}