using Microsoft.AspNetCore.Http;

namespace AccountMangment.Application.Contract.AccountApp
{
    public class CreateAccount
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public string Mobile { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
