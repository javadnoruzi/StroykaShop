using System;
using System.Collections.Generic;
using StroykaShop.Framework.Domain;

namespace AccountMangment.Domain.AccountAgg
{
    public class Account : ModelBase<long>
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public long RoleId { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }

        protected Account() { }

        public Account(
            string fullName,
            string userName,
            string password,
            long roleId,
            string mobile,
            string profilePhoto
        )
        {
            this.FullName = fullName;
            this.UserName = userName;
            this.Password = password;
            this.RoleId = roleId;
            this.Mobile = mobile;
            this.ProfilePhoto = profilePhoto;
        }

        public void Edit(
            string fullName,
            string userName,
            string password,
            long roleId,
            string mobile,
            string profilePhoto
        )
        {
            this.FullName = fullName;
            this.UserName = userName;
            this.Password = password;
            this.RoleId = roleId;
            this.Mobile = mobile;
            this.ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password) {
        Password=password;

         }
    }
}
