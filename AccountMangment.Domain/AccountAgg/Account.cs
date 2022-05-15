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
        public string Email { get; private set; }
        public string ProfilePhoto { get; private set; }
        public RoleAgg.Role Role { get; set; }
        protected Account() { }

        public Account(
            string fullName,
            string userName,
            string password,
            long roleId,
            string mobile,
            string profilePhoto,
            string email)
        {
            this.FullName = fullName;
            this.UserName = userName;
            this.Password = password;
            this.RoleId = roleId;
            if (roleId==0)
                this.RoleId = 2;


            this.Mobile = mobile;
            this.ProfilePhoto = profilePhoto;
            Email = email;
        }

        public void Edit(
            string fullName,
            string userName,
            string password,
            long roleId,
            string mobile,
            string profilePhoto,
            string email)
        {
            this.FullName = fullName;
            this.UserName = userName;
            this.Password = password;
            this.RoleId = roleId;
            this.Mobile = mobile;
            this.ProfilePhoto = profilePhoto;
            Email = email;
        }

        public void ChangePassword(string password)
        {
            Password = password;

        }
    }
}
