using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.Services
{
	public interface IMainCategoryService
	{
		Task Create(string name, CancellationToken cancellationToken);
		Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken);
		Task Delete(int id, CancellationToken cancellationToken);
		Task<MainCategoryDto> GetById(int id, CancellationToken cancellationToken);
		Task Update(MainCategory main, CancellationToken cancellationToken);
		Task<List<MainCategory>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);
	}
}
