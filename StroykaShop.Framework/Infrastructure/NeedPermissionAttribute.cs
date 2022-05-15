using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework.Infrastructure
{
    public class NeedPermissionAttribute:Attribute
    {
        public int Permission { get; set; }

    }
}
