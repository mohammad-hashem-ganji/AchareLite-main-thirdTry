
using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Infra.DB.SqlServer.EF.DB_Achare;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Ef
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly AchareDbContext _dbContext;

        public SubCategoryRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(string name,int mainCategoryId, CancellationToken cancellationToken)
        {
            var mainCategory = await _dbContext.MainCategories.FirstOrDefaultAsync(x => x.Id == mainCategoryId);
            if (mainCategory != null)
            {
                _dbContext.SubCategories.Add(new SubCategory
                {
                    Title = name,
                    MainCategoryId = mainCategoryId,
                    MainCategory = mainCategory
                });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var enetiy = await _dbContext.SubCategories
             .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (enetiy != null)
            {
                _dbContext.SubCategories.Remove(enetiy);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task<List<SubCategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            List<SubCategoryDto> categories = await _dbContext.SubCategories
           .Select(x => new SubCategoryDto
           {
               Id = x.Id,
               Title = x.Title
           }).ToListAsync(cancellationToken);
            return categories;
        }
        public async Task<(SubCategoryDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            SubCategoryDto? subCategoryEntity = await _dbContext.SubCategories
            .Select(x => new SubCategoryDto
            {
                Id = x.Id,
                Title = x.Title,
                MainCategoryId = x.MainCategoryId 
            }).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            return (subCategoryEntity != null) ? (subCategoryEntity, true) : (null, false);
        }
        public async Task<bool> Update(SubCategoryDto sub, CancellationToken cancellationToken)
        {
            var subCategory = await _dbContext.SubCategories
            .FirstOrDefaultAsync(m => m.Id == sub.Id, cancellationToken);
            if (subCategory != null)
            {
                subCategory.Title = sub.Title;
                subCategory.MainCategoryId = sub.MainCategoryId;
                _dbContext.Update(subCategory);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<SubCategoryDto>> ShowListOfSubCategoriesWhitMianCategoryId(int id, CancellationToken cancellationToken)
        {
            List<SubCategoryDto> subCategoryDtos = await _dbContext.SubCategories
                .Where(x => x.MainCategoryId == id)
                .Select(x => new SubCategoryDto
                {
                    MainCategoryId = x.MainCategoryId,
                    Id = x.Id,
                    Title = x.Title
                }).ToListAsync(cancellationToken);
            return subCategoryDtos;
        }
    }
}
