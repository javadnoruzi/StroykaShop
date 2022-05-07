using ShopMangment.Application.Contracts.ProductCategoryApp;
using ShopMangmnet.Domain.ProductCategoryAgg;
using StroykaShop.Framework;
using StroykaShop.Framework.Application;
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
        private readonly IFileUpload fileUpload;
        public ProductCategoryApplication(IProductCategoryRepository repository, IUnitofWork unitOfWork, IFileUpload fileUpload)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.fileUpload = fileUpload;
        }

        public OperationResult Create(CreatePrdouctCategory command)
        {
            unitOfWork.BeginTrann();
            OperationResult result = new OperationResult();
            try
            {
                if (!repository.Exist(x => x.Name == command.Name))
                {
                    string slug = command.Name.Slugify();
                    string Path = string.Empty;
                    
                    if (command.ParentId != 0)
                    {
                        var GetParent = repository.Get(command.ParentId);
                        if(GetParent != null)
                        {
                            Path = GetParent.Slug;
                            while (GetParent.ParentId!=0)
                            {
                                GetParent = repository.Get(GetParent.ParentId);
                                if(GetParent!=null)
                                    Path +="//"+ GetParent.Slug;
                            }
                        }
                    }
                    else
                    {
                        Path = command.Slug;
                    }


                    string PathPicture = fileUpload.Upload(command.Picture, Path);
                    repository.Create(new ProducCategory(command.Name, command.ParentId, slug, command.Keyword, command.MetaDescription, command.Descrption,PathPicture));
                    unitOfWork.SaveChanges();
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
                string slug = command.Name.Slugify();
                string PathPicture = string.Empty;
                if (command.Picture != null)
                {
                    string Path = string.Empty;

                    if (command.ParentId != 0)
                    {
                        var GetParent = repository.Get(command.ParentId);
                        if (GetParent != null)
                        {
                            Path = GetParent.Slug;
                            while (GetParent.ParentId != 0)
                            {
                                GetParent = repository.Get(GetParent.ParentId);
                                if (GetParent != null)
                                    Path += "//" + GetParent.Slug;
                            }
                        }
                    }
                    else
                    {
                        Path = command.Slug;
                    }


                    PathPicture = fileUpload.Upload(command.Picture, Path);
                }
                Category.Edit(command.Name, command.ParentId, slug, command.Keyword, command.MetaDescription, command.Descrption,PathPicture);
                unitOfWork.SaveChanges();
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
                    CreationDate = producat.CreationDate.ToFarsi(),
                    IsRemoved = producat.IsRemoved,
                    ParentId = producat.ParentId,
                    Picture = producat.Picture,
                    Descrption=producat.Descrption,
                    Keyword=producat.Keyword,
                    MetaDescription=producat.MetaDescription,
                    Slug=producat.Slug
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
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
                ParentId = x.ParentId,
                Picture = x.Picture,
                Descrption = x.Descrption,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                Childerns = GetChildern(x.Id)

            }).ToList();
            return list;
        }

        public List<PrdouctCategoryViewModel> GetAllStartMenu()
        {
            var list = repository.GetAll().Where(x=>x.ParentId==0).Select(x => new PrdouctCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
                ParentId = x.ParentId,
                Picture = x.Picture,
                Descrption = x.Descrption,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                Childerns = GetChildern(x.Id)

            }).ToList();
            return list;
        }

        public List<PrdouctCategoryViewModel> GetChildern(long id)
        {
            var list = repository.GetChildern(id).Select(x => new PrdouctCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved,
                ParentId = x.ParentId,
                Picture = x.Picture,
                Descrption = x.Descrption,
                Keyword = x.Keyword,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug

            }).ToList();
            return list;
        }

        public PrdouctCategoryViewModel GetParent(long id)
        {
            ProducCategory producCategory= repository.GetParent(id);
           return new PrdouctCategoryViewModel()
            {
                Id = producCategory.Id,
                Name = producCategory.Name,
                CreationDate = producCategory.CreationDate.ToFarsi(),
                IsRemoved = producCategory.IsRemoved,
                ParentId = producCategory.ParentId,
                Picture = producCategory.Picture,
                Descrption = producCategory.Descrption,
                Keyword = producCategory.Keyword,
                MetaDescription = producCategory.MetaDescription,
                Slug = producCategory.Slug
            };
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
                                CreationDate = a.CreationDate.ToFarsi(),
                                Picture = a.Picture,
                                Descrption = a.Descrption,
                                Keyword = a.Keyword,
                                MetaDescription = a.MetaDescription,
                                Slug = a.Slug
                            }).ToList();
                    return list;

                }
            }
            return query.ToList().Select(a => new PrdouctCategoryViewModel
            {
                Id = a.Id,
                Name = a.Name,
                ParentId = a.ParentId,
                IsRemoved = a.IsRemoved,
                CreationDate = a.CreationDate.ToFarsi(),
                Picture = a.Picture,
                Descrption = a.Descrption,
                Keyword = a.Keyword,
                MetaDescription = a.MetaDescription,
                Slug = a.Slug
            }).ToList();
        }
    }
}
