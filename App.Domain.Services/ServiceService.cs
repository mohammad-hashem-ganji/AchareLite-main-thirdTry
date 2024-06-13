using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.CategoryService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task Create(string title, int subCategoryId, CancellationToken cancellationToken)
        {
            await _serviceRepository.Create(title,subCategoryId, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _serviceRepository.Delete(id, cancellationToken);
        }

        public async Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetAll(cancellationToken);
        }

        public async Task<(ServiceDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _serviceRepository.GetById(id, cancellationToken);
        }

        public async Task<List<ServiceDto>> ShowListOfServicesWithSubCategoryId(int id, CancellationToken cancellationToken)
        {
            return await _serviceRepository.ShowListOfServicesWithSubCategoryId(id, cancellationToken);
        }

        public async Task<bool> Update(ServiceDto serviceDto, CancellationToken cancellationToken)
        {
            return await _serviceRepository.Update(serviceDto, cancellationToken);
        }
    }
}
