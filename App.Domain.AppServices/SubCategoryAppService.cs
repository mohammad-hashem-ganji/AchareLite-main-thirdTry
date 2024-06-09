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

        public SubCategoryAppService(ISubCategoryService subCategoryService) => _subCategoryService = subCategoryService;
        public async Task Create(string name, int mainCategoryid, CancellationToken cancellationToken) => await _subCategoryService.Create(name, mainCategoryid, cancellationToken);
        public async Task Delete(int id, CancellationToken cancellationToken) => await _subCategoryService.Delete(id, cancellationToken);
        public async Task<List<SubCategoryDto>> GetAll(CancellationToken cancellationToken) => await _subCategoryService.GetAll(cancellationToken);
        public async Task<(SubCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken) => await _subCategoryService.GetById(id, cancellationToken);
        public async Task<bool> Update(SubCategoryDto main, CancellationToken cancellationToken) => await _subCategoryService.Update(main, cancellationToken);
    }
}
