namespace StroykaShop.Framework.Application
{
    public class AuthViewModel{
        public long Id { get; set; }
        public string FullName { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; }

        public AuthViewModel(long id, string fullName, long roleId, string userName)
        {
            Id = id;
            FullName = fullName;
            RoleId = roleId;
            UserName = userName;
        }
    }
}