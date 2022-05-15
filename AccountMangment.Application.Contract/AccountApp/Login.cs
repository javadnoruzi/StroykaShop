using System.ComponentModel.DataAnnotations;

namespace AccountMangment.Application.Contract.AccountApp
{
    public class Login{
        [Required(ErrorMessage ="نام کاربری نمیتواند خالی باشد")]
      public string UserName { get; set; }
        [Required(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
      public string Password { get; set; }
    }
}
