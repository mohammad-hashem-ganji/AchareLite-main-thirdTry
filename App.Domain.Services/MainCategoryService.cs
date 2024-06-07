
using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.CategoryService.Services;

namespace App.Domain.Services
{
	public class MainCategoryService : IMainCategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public MainCategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task Create(string name, CancellationToken cancellationToken)
		{
			await _categoryRepository.Create(name, cancellationToken);
		}

		public async Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken)
		{
			return await _categoryRepository.GetAll(cancellationToken);
		}

		public async Task Delete(int id, CancellationToken cancellationToken)
		{
			await _categoryRepository.Delete(id, cancellationToken);
		}

		public async Task<MainCategoryDto> GetById(int id, CancellationToken cancellationToken)
		{
			return await _categoryRepository.GetById(id, cancellationToken);
		}

		public async Task Update(MainCategory main, CancellationToken cancellationToken)
		{
			await  _categoryRepository.Update(main, cancellationToken);
		}

		public async Task<List<MainCategory>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken)
		{
			return await _categoryRepository.GetAllCategoriesWithSubCategories(cancellationToken);
		}
	}
}
