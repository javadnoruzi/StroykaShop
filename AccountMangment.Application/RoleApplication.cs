using System.Collections.Generic;
using AccountMangment.Application.Contract.RoleApp;
using AccountMangment.Domain.RoleAgg;
using StroykaShop.Framework;
using StroykaShop.Framework.Infrastructure;

namespace AccountMangment.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IUnitofWork _unitOfWork;

        public RoleApplication(IRoleRepository roleRepository, IUnitofWork unitOfWork)
        {
            _RoleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public OperationResult Create(CreateRole command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Edit(EditRole command)
        {
            throw new System.NotImplementedException();
        }

        public RoleViewModel Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<RoleViewModel> GetList()
        {
            throw new System.NotImplementedException();
        }
    }
}