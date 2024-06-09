using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Infra.DB.SqlServer.EF.DB_Achare;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.Ef
{
	public class MainCategoryRepository : IMainCategoryRepository
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
		public async Task<(MainCategoryDto?,bool)> GetById(int id,CancellationToken cancellationToken)
		{
			MainCategoryDto? mainCategoryEntity = await _dbContext.MainCategories
				.Select(x=>new MainCategoryDto
				{
					Id = x.Id,
					Title = x.Title
				}).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
			return (mainCategoryEntity != null)? (mainCategoryEntity, true) : (null, false);
		}
		public async Task<List<MainCategoryDto>> GetAll(CancellationToken cancellationToken)
		{
			List<MainCategoryDto> categories = await _dbContext.MainCategories
				.Select(x=>new MainCategoryDto
				{
					Id = x.Id,
					Title = x.Title
				}).ToListAsync(cancellationToken);
			return categories;
		}

		public async Task<bool> Update(MainCategoryDto main, CancellationToken cancellationToken)
		{
			var mainCategory = await _dbContext.MainCategories
				//.Select(x=>new MainCategoryDto
    //            {
				//	Id = x.Id,
				//	Title = x.Title
    //            })
				.FirstOrDefaultAsync(m => m.Id == main.Id, cancellationToken);
            if (mainCategory != null)
            {
				mainCategory.Title = main.Title;
				_dbContext.Update(mainCategory);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return true;
			}
            else
            {
				return false;
            }

		}
		public async Task<List<MainCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken)
		{
			List<MainCategoryDto> result = await _dbContext.MainCategories
				.Include(x=>x.SubCategories)
				//ThenInclude
				.Select(x => new MainCategoryDto
                {
					Id=x.Id,
					Title=x.Title
                })
				.ToListAsync(cancellationToken);
			return result;
		}


    }
}
