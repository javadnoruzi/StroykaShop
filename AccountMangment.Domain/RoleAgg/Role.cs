using StroykaShop.Framework.Domain;
using System.Collections.Generic;

namespace AccountMangment.Domain.RoleAgg
{
    public class Role:ModelBase<long>
    {
        public string Name { get; private set; }
        public List<Permissions>  Permissions { get; set; }
        public List<AccountAgg.Account> Accounts { get; set; }

        protected Role() { }
        public Role(string name, List<Permissions> permissions)
        {
            Name = name;
            Permissions = permissions;
            Accounts = new List<AccountAgg.Account>();
        }
        public void Edit(string name, List<Permissions> permissions)
        {
            Name = name;
            Permissions = permissions;
           
        }
    }
}