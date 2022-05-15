using System.Collections.Generic;

namespace StroykaShop.Framework.Application
{
    public class AuthViewModel{
        public long Id { get; set; }
        public string FullName { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; }
        public List<int> Permissions { get; set; }
        public AuthViewModel() { }
        public AuthViewModel(long id, string fullName, long roleId, string userName, List<int> permissions)
        {
            Id = id;
            FullName = fullName;
            RoleId = roleId;
            UserName = userName;
            Permissions = permissions;
        }
    }
}