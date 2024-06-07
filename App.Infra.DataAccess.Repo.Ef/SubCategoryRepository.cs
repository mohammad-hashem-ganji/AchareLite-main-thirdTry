
using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Infra.DB.SqlServer.EF.DB_Achare;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
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


        public void Creat(string name, int mainCategoryId)
        {
            _dbContext.Add(new SubCategory { Title = name });
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbContext.SubCategories.FirstOrDefault(s => s.Id == id);
            if (entity != null)
            {
                _dbContext.SubCategories.Remove(entity);
                _dbContext.SaveChanges();
            }
        }


        public List<SubCategory> GetAll()
        {
            var subCategories = _dbContext.SubCategories.ToList();
            return subCategories;
        }


        public SubCategory Edit(int id)
        {
            var SubCategoryEntity = _dbContext.SubCategories.FirstOrDefault(s => s.Id == id);
            return SubCategoryEntity;
        }

        public void Update(SubCategoryDto sub)
        {
            SubCategory subCategory = _dbContext.SubCategories.FirstOrDefault(c => c.Id == sub.Id);
            subCategory.Title = sub.Title;
            subCategory.MainCategoryId = sub.MainCategoryId;
            _dbContext.Update(subCategory);
            _dbContext.SaveChanges();
        }


    }
}
