
namespace StroykaShop.Framework.Application
{
    public interface IAuthHelper
    {
         void SignIn(AuthViewModel account);
         void SignOut();
         bool ISVeriFired();
    }

}