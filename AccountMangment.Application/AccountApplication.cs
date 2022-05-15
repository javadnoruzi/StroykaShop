using AccountMangment.Application.Contract.AccountApp;
using StroykaShop.Framework;
using StroykaShop.Framework.Application;
using System.Collections.Generic;
using AccountMangment.Domain.AccountAgg;
using StroykaShop.Framework.Infrastructure;
using System.Linq;

namespace AccountMangment.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IFileUpload _FileUplaoad;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitofWork _unitOfwork;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository, IFileUpload fileUplaoad, IPasswordHasher passwordHasher, IUnitofWork unitOfwork, IAuthHelper authHelper)
        {
            _AccountRepository = accountRepository;
            _FileUplaoad = fileUplaoad;
            _passwordHasher = passwordHasher;
            _unitOfwork = unitOfwork;
            _authHelper = authHelper;
        }

        public OperationResult ChangePassword(ChangePasswordAccount Command)
        {
            OperationResult operationResult=new OperationResult();
            _unitOfwork.BeginTrann();
            try
            {
                if (Command==null)return operationResult.Failed(ResultMessage.NullCommand);
                
                if(string.IsNullOrWhiteSpace(Command.Password) || string.IsNullOrEmpty(Command.Repassword))return operationResult.Failed("رمز عبور نمیتواند خالی باشد.");

                if(Command.Password!=Command.Repassword)return operationResult.Failed("رمز عبور با تکرار یکسان نیست");
                
                Account user=_AccountRepository.Get(Command.id);
                if(user==null)return operationResult.Failed(ResultMessage.NullCommand);
                string Password=_passwordHasher.Hash(Command.Password);
                user.ChangePassword(Password);
                _unitOfwork.SaveChanges();
                return operationResult.Success();
                    

            }
            catch (System.Exception ex)
            {
                _unitOfwork.RollBackTran();
                return operationResult.Failed(ResultMessage.Faild + "  " + ex.Message);
                
            }
        }

        public OperationResult Create(CreateAccount command)
        {
            OperationResult operation = new OperationResult();
            _unitOfwork.BeginTrann();
            try
            {
                if (command == null) return operation.Failed("ورودی ها نیمتواتد خالی باشد");
                if (command.UserName == null) return operation.Failed(ResultMessage.Duplicateed);
                if (_AccountRepository.Exist(x => x.UserName == command.UserName)) return operation.Failed("نام کاربری موجود است");
                if (_AccountRepository.Exist(x => x.Email == command.Email)) return operation.Failed("ایمیل موجود است");
                string Password = _passwordHasher.Hash(command.Password);

                string Path = _FileUplaoad.Upload(command.ProfilePhoto, "ProfilePicture//");
                _AccountRepository.Create(new Account(command.FullName, command.UserName, Password, command.RoleId, command.Mobile, Path,command.Email));

                _unitOfwork.SaveChanges();
                _unitOfwork.CommittTran();
                return operation.Success();


            }
            catch (System.Exception ex)
            {

                _unitOfwork.RollBackTran();
                return operation.Failed(ResultMessage.Faild + "  " + ex.Message);
            }
        }

        public OperationResult Edit(EditAccount command)
        {
            OperationResult operation = new OperationResult();
            _unitOfwork.BeginTrann();
            try
            {
                if (command == null) return operation.Failed("ورودی ها نیمتواتد خالی باشد");
                if (command.UserName == null) return operation.Failed(ResultMessage.Duplicateed);
                if (_AccountRepository.Exist(x => (x.Id != command.Id && x.UserName == command.UserName))) return operation.Failed("نام کاربری موجود است");
                var user = _AccountRepository.Get(command.Id);

                if (user == null) return operation.Failed(ResultMessage.NotFound);
                string Path = string.Empty;
                if (command.ProfilePhoto != null)
                    Path = _FileUplaoad.Upload(command.ProfilePhoto, "ProfilePicture//");

                user.Edit(command.FullName, command.UserName, string.Empty, command.RoleId, command.Mobile, Path,command.Email);

                _unitOfwork.SaveChanges();
                _unitOfwork.CommittTran();
                return operation.Success();


            }
            catch (System.Exception ex)
            {

                _unitOfwork.RollBackTran();
                return operation.Failed(ResultMessage.Faild + "  " + ex.Message);
            }
        }

        public AccountViewModel Get(long id)
        {
            Account user = _AccountRepository.Get(id);
            return new AccountViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                CreationDate = user.CreationDate.ToFarsi(),
                Mobile = user.Mobile,
                ProfilePhoto = user.ProfilePhoto,
                UserName = user.UserName,
                RoleId = user.RoleId

            };
        }

        public List<AccountViewModel> GetList()
        {
            return _AccountRepository.GetAll().Select(user => new AccountViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                CreationDate = user.CreationDate.ToFarsi(),
                Mobile = user.Mobile,
                ProfilePhoto = user.ProfilePhoto,
                UserName = user.UserName,
                RoleId = user.RoleId
            }

            ).ToList();
        }

        public OperationResult Login(Login commadn)
        {
           OperationResult opearation=new OperationResult();
           if(commadn==null)return opearation.Failed(ResultMessage.NullCommand);

           Account account=_AccountRepository.Get(commadn.UserName);
           if(account==null) _AccountRepository.GetbyMobile(commadn.UserName);

            if (account == null) _AccountRepository.GetEmail(commadn.UserName);

            if (account == null) return opearation.Failed("نام کاربری یا رمز عبور اشتباه است");

            var Result=_passwordHasher.Check(account.Password,commadn.Password);
             if(!Result.Verified)
             {
                _authHelper.SignIn(new AuthViewModel(account.Id, account.FullName, account.RoleId, account.UserName,new List<int>()));
                return opearation.Success();
             }
            else
            {
                return opearation.Failed();
            }


        }
    }
}