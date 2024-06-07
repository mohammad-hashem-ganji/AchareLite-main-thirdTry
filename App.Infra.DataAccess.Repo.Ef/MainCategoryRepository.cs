using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Infra.DB.SqlServer.EF.DB_Achare;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.Ef
{
	public class MainCategoryRepository : ICategoryRepository
	{
		private readonly AchareDbContext _dbContext;

		public MainCategoryRepository(AchareDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Create(string name,CancellationToken cancellationToken)
		{
			_dbContext.MainCategories.Add(new MainCategory
			{
				Title = name,
			});

			await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task Delete(int id,CancellationToken cancellationToken)
		{
			var enetiy = await _dbContext.MainCategories
				.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

			if (enetiy != null)
			{
				_dbContext.MainCategories.Remove(enetiy);
				await _dbContext.SaveChangesAsync(cancellationToken);
			}

		}

		public async Task<MainCategoryDto> GetById(int id,CancellationToken cancellationToken)
		{
			var mainCategoryEntity = await _dbContext.MainCategories
				.Select(x=>new MainCategoryDto
				{
					Id = x.Id,
					Title = x.Title
				}).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

			return mainCategoryEntity;
		}

		public async Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken)
		{
			var categories = await _dbContext.MainCategories
				.Select(x=>new MainCategoryDto
				{
					Id = x.Id,
					Title = x.Title
				}).ToListAsync(cancellationToken);

			return categories;
		}

		public async Task Update(MainCategory main, CancellationToken cancellationToken)
		{
			MainCategory mainCategory = await _dbContext.MainCategories
				.FirstOrDefaultAsync(m => m.Id == main.Id, cancellationToken);

			mainCategory.Title = main.Title;
			_dbContext.Update(mainCategory);
			await _dbContext.SaveChangesAsync(cancellationToken);
		}


		public async Task<List<MainCategory>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken)
		{
			var result = await _dbContext.MainCategories
				.Include(x=>x.SubCategories)
				//ThenInclude
				.ToListAsync(cancellationToken);

			return result;
		}
	}
}
