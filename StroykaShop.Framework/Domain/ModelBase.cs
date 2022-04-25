using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroykaShop.Framework.Domain
{
    public class ModelBase<Tkey>
    {
        public Tkey Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public ModelBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
