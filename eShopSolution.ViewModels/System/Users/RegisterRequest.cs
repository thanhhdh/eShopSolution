using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Trường này không được trống")]
        public string? FirstName { get; set; }
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Trường này không được trống")]

        public string? LastName { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Trường này không được trống")]
        [DataType(DataType.Date)]
        public DateTime? Dob { get ; set; }
        [Required(ErrorMessage = "Trường này không được trống")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Trường này không được trống")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Trường này không được trống")]
        public string? UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Trường này không được trống")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Trường này không được trống")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

    }
}
