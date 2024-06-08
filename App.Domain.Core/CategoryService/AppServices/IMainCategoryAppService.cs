using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.AppServices
{
    public interface IMainCategoryAppService
    {
		Task Create(string name, CancellationToken cancellationToken);
		Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken);
		Task Delete(int id, CancellationToken cancellationToken);
		Task<(MainCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken);
		Task<bool> Update(MainCategoryDto main, CancellationToken cancellationToken);
		Task<List<MainCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);

	}
}
