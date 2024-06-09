using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.Services
{
    public interface ISubCategoryService
    {
		Task Create(string name, int mainCategoryId, CancellationToken cancellationToken);
		Task<List<SubCategoryDto>> GetAll(CancellationToken cancellationToken);
		Task Delete(int id, CancellationToken cancellationToken);
		Task<(SubCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken);
		Task<bool> Update(SubCategoryDto main, CancellationToken cancellationToken);
		//Task<List<SubCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);
	}
}
