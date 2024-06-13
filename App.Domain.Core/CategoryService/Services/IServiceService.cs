using App.Domain.Core.CategoryService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CategoryService.Services
{
    public interface IServiceService
    {
		Task Create(string title, int subCategoryId, CancellationToken cancellationToken);
		Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken);
		Task Delete(int id, CancellationToken cancellationToken);
		Task<(ServiceDto?, bool)> GetById(int id, CancellationToken cancellationToken);
		Task<bool> Update(ServiceDto serviceDto, CancellationToken cancellationToken);
		//Task<List<SubCategoryDto>> GetAllCategoriesWithSubCategories(CancellationToken cancellationToken);
		Task<List<ServiceDto>> ShowListOfServicesWithSubCategoryId(int id, CancellationToken cancellationToken);
	}
}
