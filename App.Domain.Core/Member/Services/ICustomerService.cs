using App.Domain.Core.Member.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetById(int id, CancellationToken cancellationToken);
        Task<string> GetCustomerName(int customerId, CancellationToken cancellationToken);
        Task<bool> Update(CustomerDto customerDto, CancellationToken cancellationToken);
    }
}
