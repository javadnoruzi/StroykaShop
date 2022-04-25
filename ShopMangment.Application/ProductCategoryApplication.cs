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
            if (!repository.Exist(x => x.Id == id))
            {
                var producat = repository.Get(id);
                return new PrdouctCategoryViewModel()
                {
                    Id = producat.Id,
                    Name = producat.Name,
                    CreationDate = producat.CreationDate.ToString(),
                    IsRemoved = producat.IsRemoved,
                    ParentId = producat.ParentId
                };
            }
            else
            {
                return new PrdouctCategoryViewModel();
            }

        }

        public List<PrdouctCategoryViewModel> GetAll()
        {
            var list = repository.GetAll().Select(x => new PrdouctCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(),
                IsRemoved = x.IsRemoved,
                ParentId = x.ParentId

            }).ToList();
            return list;
        }

        public List<PrdouctCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            List<PrdouctCategoryViewModel> list = new List<PrdouctCategoryViewModel>();
            var query = repository.GetAll();
            if (command.Id != 0)
            {
                query = query.Where(x => x.Id == command.Id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(command.ParentName))
            {
                if (repository.Exist(x => command.Name.Contains(command.ParentName)))
                {
                    var parentname = repository.Get(command.Name);
                    list = (from a in query
                            join b in parentname on a.Id equals b.Id
                            select new PrdouctCategoryViewModel
                            {
                                Id = a.Id,
                                Name = a.Name,
                                ParentId = a.ParentId,
                                IsRemoved = a.IsRemoved,
                                CreationDate = a.CreationDate.ToString()
                            }).ToList();
                    return list;

                }
            }
            return query.ToList().Select(a=>new PrdouctCategoryViewModel{
                Id = a.Id,
                Name = a.Name,
                ParentId = a.ParentId,
                IsRemoved = a.IsRemoved,
                CreationDate = a.CreationDate.ToString() }).ToList();
        }
    }
}
