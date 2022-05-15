using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMangment.Domain.RoleAgg
{
   public class Permissions
    {
        public long Id { get; private set; }
        public int  Code { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        protected Permissions() { }
        public Permissions(int code)
        {
            Code = code;
        }
        public Permissions( int code, long roleId)
        {
            Code = code;
            RoleId = roleId;
        }
    }
}
