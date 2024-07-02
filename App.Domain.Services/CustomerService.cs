using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetById(id, cancellationToken);
        }

        public async Task<string?> GetCustomerName(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(customerId, cancellationToken);
            if (customer != null)
            {
                if (customer.FirstName != null)
                {
                    return customer.FirstName;
                }
                else
                {
                    return "مشتری نام خود را وارد نکرده است";
                }
            }
            else
            {
                return "مشتری پیدا نشد";
            }
        }
    }
}
