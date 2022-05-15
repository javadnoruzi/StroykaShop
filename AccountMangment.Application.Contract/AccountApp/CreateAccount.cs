using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AccountMangment.Application.Contract.AccountApp
{
    public class CreateAccount
    {
        public string FullName { get; set; }
        [Required(ErrorMessage ="وارد کردن نام کاربزی الزامی است")]
        [MinLength(5,ErrorMessage ="حداقل کاراکتر 5")]
        public string UserName { get; set; }
        [MinLength(6, ErrorMessage = "حداقل کاراکتر 6")]
        public string Password { get; set; }
        public string RePassword { get; set; }
        public long RoleId { get; set; }
        
        public string Mobile { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
