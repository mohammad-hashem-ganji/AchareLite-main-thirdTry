using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class ServiceAppService : IServiceAppService
    {
        private readonly IServiceService _serviceService;

        public ServiceAppService(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task Create(string title, int subCategoryId, CancellationToken cancellationToken)
        {
            await _serviceService.Create(title, subCategoryId, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _serviceService.Delete(id, cancellationToken);
        }

        public async Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _serviceService.GetAll(cancellationToken);
        }

        public async Task<(ServiceDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _serviceService.GetById(id, cancellationToken);
        }

        public async Task<List<ServiceDto>> ShowListOfServicesWithSubCategoryId(int id, CancellationToken cancellationToken)
        {
            return await _serviceService.ShowListOfServicesWithSubCategoryId(id, cancellationToken);
        }

        public async Task<bool> Update(ServiceDto serviceDto, CancellationToken cancellationToken)
        {
            return await _serviceService.Update(serviceDto, cancellationToken);
        }
    }
}
