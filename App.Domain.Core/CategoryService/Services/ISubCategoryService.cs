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
        void Creat(string name,int mainCategoryId);
        void Delete(int id);
        List<SubCategory> GetAll();
        SubCategory Edit(int id);
        void Update(SubCategoryDto sub);
    }
}
