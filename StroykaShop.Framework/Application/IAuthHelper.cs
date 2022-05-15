
using System.Collections.Generic;

namespace StroykaShop.Framework.Application
{
    public interface IAuthHelper
    {
         void SignIn(AuthViewModel account);
         void SignOut();
         bool ISVeriFired();
        AuthViewModel Getinfo();
        List<int> GetPermissions();
    }

}