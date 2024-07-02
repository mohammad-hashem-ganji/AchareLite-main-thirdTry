using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _customerService.GetById(id, cancellationToken);
        }

        public async Task<string> GetCustomerName(int customerId, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerName(customerId, cancellationToken);
        }
    }
}
