using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;

namespace App.Domain.Core.CategoryService.Data.Repositories
{
    public interface IMainCategoryRepository
    {
		Task Create(string name, CancellationToken cancellationToken);
		Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken);
		Task Delete(int id, CancellationToken cancellationToken);
		Task<(MainCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken);
		Task<bool> Update(MainCategoryDto main, CancellationToken cancellationToken);
		Task<List<MainCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);
    }
}
