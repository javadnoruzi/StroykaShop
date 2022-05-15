using System;
using System.Collections.Generic;
using StroykaShop.Framework.Domain;

namespace AccountMangment.Domain.AccountAgg
{
    public interface IAccountRepository:IRepository<long,Account>
    {
         Account Get(string UnserName);
        Account GetbyMobile(string Mobile);
        Account GetEmail(string Emial);
    }
}