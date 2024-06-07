using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;

namespace App.Domain.Core.CategoryService.Data.Repositories
{
    public interface ICategoryRepository
    {
		Task Create(string name, CancellationToken cancellationToken);
		Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken);
		Task Delete(int id, CancellationToken cancellationToken);
		Task<MainCategoryDto> GetById(int id, CancellationToken cancellationToken);
		Task Update(MainCategory main, CancellationToken cancellationToken);
		Task<List<MainCategory>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);


    }
}
