using System;
using System.Collections.Generic;
using System.Linq;
using ShopMangment.Application.Contracts.BrandApp;
using ShopMangmnet.Domain.BrandAgg;
using StroykaShop.Framework;
using StroykaShop.Framework.Application;
using StroykaShop.Framework.Infrastructure;

namespace ShopMangment.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly ShopMangmnet.Domain.BrandAgg.IBrandRepository _BrandRepository;
        private readonly IFileUpload fileUpload;
        private readonly IUnitofWork _unitOfWork;

        public BrandApplication(IBrandRepository brandRepository, IFileUpload fileUpload, IUnitofWork unitOfWork)
        {
            _BrandRepository = brandRepository;
            this.fileUpload = fileUpload;
            _unitOfWork = unitOfWork;
        }

        public OperationResult Create(CreateBrand command)
        {
            OperationResult operation = new OperationResult();
            _unitOfWork.BeginTrann();
            try
            {

                if (command == null) return operation.Failed(ResultMessage.NullCommand);

                if (!string.IsNullOrWhiteSpace(command.Name)) return operation.Failed(ResultMessage.NullCommand + Environment.NewLine + "-نام خالی است");

                if (command.CategoryId == 0) return operation.Failed("دسته بندی نمیتواند خالی باشد");

                string slug = "Brands//" + command.Name.Slugify();
                string path = fileUpload.Upload(command.Picture, slug);
                _BrandRepository.Create(new Brand(command.Name, path, command.Description, command.CategoryId));
                _unitOfWork.SaveChanges();
                _unitOfWork.CommittTran();
                return operation.Success();
            }
            catch (System.Exception ex)
            {
                _unitOfWork.RollBackTran();
                return operation.Failed(ResultMessage.Faild + Environment.NewLine + ex.Message);
            }


        }

        public OperationResult Edit(EditBrand command)
        {
            OperationResult operation = new OperationResult();
            _unitOfWork.BeginTrann();
            try
            {
                Brand brand = _BrandRepository.Get(command.Id);
                if (brand == null) return operation.Failed(ResultMessage.NotFound);

                if (command == null) return operation.Failed(ResultMessage.NullCommand);

                if (!string.IsNullOrWhiteSpace(command.Name)) return operation.Failed(ResultMessage.NullCommand + Environment.NewLine + "-نام خالی است");

                if (command.CategoryId == 0) return operation.Failed("دسته بندی نمیتواند خالی باشد");

                string slug = "Brands//" + command.Name.Slugify();
                string path = fileUpload.Upload(command.Picture, slug);
                brand.Edit(command.Name, path, command.Description, command.CategoryId);
                _unitOfWork.SaveChanges();
                _unitOfWork.CommittTran();
                return operation.Success();
            }
            catch (System.Exception ex)
            {
                _unitOfWork.RollBackTran();
                return operation.Failed(ResultMessage.Faild + Environment.NewLine + ex.Message);
            }
        }

        public BrandViewModel Get(long id)
        {
            Brand brand = _BrandRepository.Get(id);
            return new BrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                CategoryId = brand.CategoryId,
                CreationDate = brand.CreationDate.ToFarsi(),
                Description = brand.Description,
                Picture = brand.Picture
            };
        }

        public List<BrandViewModel> GetAll()
        {
           return _BrandRepository.GetAll().Select(brand=>new BrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                CategoryId = brand.CategoryId,
                CreationDate = brand.CreationDate.ToFarsi(),
                Description = brand.Description,
                Picture = brand.Picture
            }).ToList();
        }
    }
}