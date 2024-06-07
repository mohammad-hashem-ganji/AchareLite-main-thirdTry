using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.CategoryService.Services;
using App.Domain.Core.CategoryService.Data.Repositories;

namespace App.Domain.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }


        public void Creat(string name, int mainCategoryId)
        {
            _subCategoryRepository.Creat(name,mainCategoryId);
        }

        public void Delete(int id)
        {
            _subCategoryRepository.Delete(id);
        }

        public SubCategory Edit(int id)
        {
            var entity = _subCategoryRepository.Edit(id);
            return entity;
        }

        public List<SubCategory> GetAll()
        {
            var entities = _subCategoryRepository.GetAll();
            return entities;
        }

        public void Update(SubCategoryDto sub)
        {
            _subCategoryRepository.Update(sub);
        }



    }
}
