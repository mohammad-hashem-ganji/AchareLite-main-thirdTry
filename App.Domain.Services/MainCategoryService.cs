
using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.CategoryService.Services;

namespace App.Domain.Services
{
	public class MainCategoryService : IMainCategoryService
	{
		private readonly IMainCategoryRepository _categoryRepository;

		public MainCategoryService(IMainCategoryRepository categoryRepository)
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

		public async Task<(MainCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken)
		{
			return await _categoryRepository.GetById(id, cancellationToken);
		}

		public async Task<bool> Update(MainCategoryDto main, CancellationToken cancellationToken)
		{
		   return	await  _categoryRepository.Update(main, cancellationToken);
		}

		public async Task<List<MainCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken)
		{
			return await _categoryRepository.GetAllCategoriesWithSubCategories(cancellationToken);
		}
	}
}
