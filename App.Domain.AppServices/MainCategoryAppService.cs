using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.CategoryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class MainCategoryAppService : IMainCategoryAppService
    {
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryAppService(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }

        public async Task Create(string name, CancellationToken cancellationToken)
        {
            await _mainCategoryService.Create(name, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _mainCategoryService.Delete(id, cancellationToken);
        }

        public async Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _mainCategoryService.GetAll(cancellationToken);
        }

        public async Task<List<MainCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken)
        {
            return await _mainCategoryService.GetAllCategoriesWithSubCategories(cancellationToken);
        }

        public async Task<(MainCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _mainCategoryService.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(MainCategoryDto main, CancellationToken cancellationToken)
        {
           return await _mainCategoryService.Update(main, cancellationToken);
        }


    }
}
