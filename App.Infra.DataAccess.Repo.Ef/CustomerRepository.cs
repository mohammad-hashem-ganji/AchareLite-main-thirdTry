using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Ef
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AchareDbContext _dbContext;

        public CustomerRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CustomerDto> GetById(int id, CancellationToken cancellationToken)
        {
            CustomerDto? customer = await _dbContext.Customers
                .Include(a => a.Orders)
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ApplicationUserId = x.ApplicationUserId,
                    NCode = x.NCode,
                    OrderIds = x.Orders.Select(x => x.Id).ToList()
                }).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            return (customer == null) ? null! : customer;

        }
    }
}
