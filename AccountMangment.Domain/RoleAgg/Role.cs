using StroykaShop.Framework.Domain;

namespace AccountMangment.Domain.RoleAgg
{
    public class Role:ModelBase<long>
    {
        public string Name { get; private set; }
    }
}