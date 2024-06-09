using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.CategoryService.Services;
using App.Domain.Core.CategoryService.Data.Repositories;

namespace App.Domain.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository )=> _subCategoryRepository = subCategoryRepository;
        public async Task Create(string name, int mainCategoryId, CancellationToken cancellationToken) => await _subCategoryRepository.Create(name,mainCategoryId,cancellationToken);

        public async Task Delete(int id, CancellationToken cancellationToken) => await _subCategoryRepository.Delete(id,cancellationToken);

        public async Task<(SubCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken) =>  await _subCategoryRepository.GetById(id, cancellationToken);

        public async Task<List<SubCategoryDto>> GetAll(CancellationToken cancellationToken) => await _subCategoryRepository.GetAll(cancellationToken);

        public async Task<bool> Update(SubCategoryDto main, CancellationToken cancellationToken) => await _subCategoryRepository.Update(main,cancellationToken);

       
    }
}
