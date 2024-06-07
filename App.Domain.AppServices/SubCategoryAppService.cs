using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CategoryService.Services;

namespace App.Domain.AppServices
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryAppService(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }


        public void Creat(string name, int mainCategoryId)
        {
            _subCategoryService.Creat(name,mainCategoryId);
        }

        public void Delete(int id)
        {
            _subCategoryService.Delete(id);
        }

        public SubCategory Edit(int id)
        {
            SubCategory sub = _subCategoryService.Edit(id);
            return sub;
        }

        public List<SubCategory> GetAll()
        {
            List<SubCategory> subCategories = _subCategoryService.GetAll();
            return subCategories;
        }

        public void Update(SubCategoryDto sub)
        {
            _subCategoryService.Update(sub);
        }
    }
}
