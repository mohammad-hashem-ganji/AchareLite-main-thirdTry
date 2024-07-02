using App.Domain.Core.Member.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetById(int id, CancellationToken cancellationToken);
    }
}
