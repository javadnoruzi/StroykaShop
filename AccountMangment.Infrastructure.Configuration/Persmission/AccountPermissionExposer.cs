using StroykaShop.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMangmentBootstrapper.Persmission
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Account",new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermissions.ListAccount,"ListAccount"),
                        new PermissionDto(AccountPermissions.SearchAccount,"SearchAccount"),
                        new PermissionDto(AccountPermissions.CreateAccount,"CreateAccount"),
                        new PermissionDto(AccountPermissions.EditAccount,"EditAccount"),

                    }
                },
                {
                    "Role",new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermissions.ListRole,"ListRole"),
                        new PermissionDto(AccountPermissions.SearchRole,"SearchRole"),
                        new PermissionDto(AccountPermissions.CreateRole,"CreateRole"),
                        new PermissionDto(AccountPermissions.EditRole,"EditRole"),

                    }
                }

            };
        }
        public static class AccountPermissions
        {
            //Account
            public const int ListAccount = 1;
            public const int SearchAccount = 2;
            public const int CreateAccount = 3;
            public const int EditAccount = 4;

            //Role
            public const int ListRole = 10;
            public const int SearchRole = 11;
            public const int CreateRole = 12;
            public const int EditRole = 13;

        }
    }
}
