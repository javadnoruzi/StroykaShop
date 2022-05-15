using StroykaShop.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangmnet.Domain.ColorAgg
{
    public  class Color:ModelBase<long>
    {
        public string Name { get; private set; }

        public Color(string name)
        {
            Name = name;
        }
    }
}
