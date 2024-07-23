using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Entities;
using App.Infra.Cache.InMemoryCache;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Ef
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AchareDbContext _dbContext;
        private readonly IInMemoryCacheService _inMemoryCacheService;
        public ServiceRepository(AchareDbContext dbContext, IInMemoryCacheService inMemoryCacheService)
        {
            _dbContext = dbContext;
            _inMemoryCacheService = inMemoryCacheService;
        }

        public async Task Create(string title, int subCategoryId, CancellationToken cancellationToken)
        {
            var subCategory = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == subCategoryId, cancellationToken);
            if (subCategory != null)
            {
                _dbContext.Services.Add(new Service
                {
                    Title = title,
                    SubCategoryId = subCategoryId,
                    SubCategory = subCategory
                });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            Service? enetiy = await _dbContext.Services.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (enetiy != null)
            {
                _dbContext.Services.Remove(enetiy);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = _inMemoryCacheService.Get<List<ServiceDto>>("GetAllServices");
            if (result != null)
            {
                result = await _dbContext.Services
               .Select(x => new ServiceDto
               {
                   Id = x.Id,
                   Title = x.Title,
                   SubCategoryId = x.SubCategoryId
               }).ToListAsync(cancellationToken);
                _inMemoryCacheService.SetSliding("GetAllServices", result, 100);
            }
            return result;
        }

        public async Task<(ServiceDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            var serviceDto = _inMemoryCacheService.Get<ServiceDto?>("GetServiceById");
            if (serviceDto != null)
            {
                serviceDto = await _dbContext.Services
                .Select(x => new ServiceDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    SubCategoryId = x.SubCategoryId
                }).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
                _inMemoryCacheService.SetSliding("GetServiceById", serviceDto, 100);
            }
            return (serviceDto != null) ? (serviceDto, true) : (null, false);
        }

        public async Task<List<ServiceDto>> ShowListOfServicesWithSubCategoryId(int id, CancellationToken cancellationToken)
        {
            var serviceDtos = _inMemoryCacheService.Get<List<ServiceDto>>("GetListOfServicesWithSubCategoryId");
            if (serviceDtos != null)
            {
                serviceDtos = await _dbContext.Services
                   .Where(x => x.SubCategoryId == id)
                   .Select(x => new ServiceDto
                   {
                       SubCategoryId = x.SubCategoryId,
                       Id = x.Id,
                       Title = x.Title
                   }).ToListAsync(cancellationToken);
                _inMemoryCacheService.SetSliding("GetListOfServicesWithSubCategoryId", serviceDtos, 100);
            }
            return serviceDtos;
        }

        public async Task<bool> Update(ServiceDto serviceDto, CancellationToken cancellationToken)
        {
            var service = await _dbContext.Services
            .FirstOrDefaultAsync(m => m.Id == serviceDto.Id, cancellationToken);
            if (service != null)
            {
                service.Title = serviceDto.Title;
                service.SubCategoryId = serviceDto.SubCategoryId;
                _dbContext.Update(service);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
