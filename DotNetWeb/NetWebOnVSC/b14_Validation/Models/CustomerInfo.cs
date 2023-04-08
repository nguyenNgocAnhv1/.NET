using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfor
{
    [DisplayName("Tên")]
    [Required(ErrorMessage ="Phải nhập tên khách")]
    [StringLength(20,MinimumLength =3,ErrorMessage ="{0} phải dài từ {2} đến {1}")]
    [ModelBinder(BinderType = typeof(UseNameBinding))]
    public string Name { get; set; }
    [DisplayName("Email")]
    [EmailAddress(ErrorMessage ="Phải nhập địa chỉ email phù hợp")]
    [Required(ErrorMessage ="Yêu cầu có {0}")]
    public string Email { get; set; }
    [DisplayName("Năm sinh")]   
    [SoChan]
    public int? Year { get; set; }
}