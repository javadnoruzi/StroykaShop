using ShopMangment.Application.Contracts.ProductCategoryApp;
using ShopMangmnet.Domain.ProductCategoryAgg;
using StroykaShop.Framework;
using StroykaShop.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMangment.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository repository;
        private readonly IUnitofWork unitOfWork;

        public ProductCategoryApplication(IProductCategoryRepository repository, IUnitofWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public OperationResult Create(CreatePrdouctCategory command)
        {
            unitOfWork.BeginTrann();
            OperationResult result = new OperationResult();
            try
            {
                if (!repository.Exist(x => x.Name == command.Name))
                {
                    repository.Create(new ProducCategory(command.Name, command.ParentId));
                    unitOfWork.CommittTran();
                    return result.Success();
                }
                else
                {
                    unitOfWork.RollBackTran();
                    return result.Failed();
                }
               
            }
            catch (Exception ex)
            {
                unitOfWork.RollBackTran();
                return result.Failed(ex.Message);
            }
        }

        public OperationResult Edit(EditProductCategory command)
        {
            unitOfWork.BeginTrann();
            OperationResult result = new OperationResult();
            try
            {

                var Category = repository.Get(command.Id);
                Category.Edit(command.Name, command.ParentId);
                unitOfWork.CommittTran();
                return result.Success();
            }
            catch (Exception ex)
            {
                unitOfWork.RollBackTran();
                return result.Failed(ex.Message);
            }
        }

        public PrdouctCategoryViewModel Get(long id)
        {
            var producat= repository.Get(id);
            return new PrdouctCategoryViewModel() {Id=producat.Id,
            Name=producat.Name,
            CreationDate=producat.CreationDate.ToString(),
            IsRemoved=producat.IsRemoved,
            ParentId=producat.ParentId};
        }

        public List<PrdouctCategoryViewModel> GetAll()
        {
            var list = repository.GetAll().Select(x => new PrdouctCategoryViewModel
            {
                Id=x.Id,
                Name=x.Name,
                CreationDate=x.CreationDate.ToString(),
                IsRemoved=x.IsRemoved,
                ParentId=x.ParentId

            }).ToList();
            return list;
        }

        public List<PrdouctCategoryViewModel> Search(ProductCategorySearchModel command)
        {
          
        }
    }
}
