using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace StroykaShop.Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel Getinfo()
        {
            if (!ISVeriFired())
                return new AuthViewModel();

            var claims = _contextAccessor.HttpContext.User.Claims;
            return new AuthViewModel
            {
                Id = long.Parse((claims.FirstOrDefault(x => x.Type == "Id").Value)),
                FullName = claims.FirstOrDefault(x => x.Type == "FullName").Value,
                RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == "RoleId").Value),
                UserName = claims.FirstOrDefault(x => x.Type == "UserName").Value,
                Permissions = JsonConvert.DeserializeObject < List<int> > (claims.FirstOrDefault(x => x.Type == "Permissions").Value)

            };
        }

        public bool ISVeriFired()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
        public List<int> GetPermissions()
        {
            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x=>x.Type== "Permissions")?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }

        public void SignIn(AuthViewModel account)
        {
            if (account.FullName == null) account.FullName = "User";
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.FullName),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.UserName), // Or Use ClaimTypes.NameIdentifier
                new Claim("Permissions", permissions),
              
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}