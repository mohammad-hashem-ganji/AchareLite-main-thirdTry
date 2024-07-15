using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Entities;
using App.Domain.Core.OrderAgg.Entities;
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
        public async Task<CustomerDto> GetById(int customerId, CancellationToken cancellationToken)
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
                    OrderIds = x.Orders.Select(x => x.Id).ToList(),
                    ImageData = x.Image!,
                    Mobile = x.Mobile
                }).FirstOrDefaultAsync(m => m.Id == customerId, cancellationToken);
            if (customer?.ImageData != null)
            {
                customer.ExistingImageBase64 = Convert.ToBase64String(customer.ImageData);
            }
            return (customer == null) ? null! : customer;
        }
        public async Task<bool> Update(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customers
                .Include(x => x.Orders)
                .FirstOrDefaultAsync(c => c.Id == customerDto.Id);
            if (customer != null)
            {
                customer.NCode = customerDto.NCode;
                customer.Mobile = customerDto.Mobile;
                customer.FirstName = customerDto.FirstName;
                customer.LastName = customerDto.LastName;
                customer.Orders ??= new List<Order>();
                customer.Orders.Clear();
                if (customerDto.OrderIds != null)
                {
                    foreach (var customerId in customerDto.OrderIds)
                    {
                        var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
                        if (order != null)
                        {
                            customer.Orders.Add(order);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (customerDto.Image != null)
                {
                    string ext = System.IO.Path.GetExtension(customerDto.Image.FileName);
                    if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png")
                    {
                        if (customerDto.Image.Length <= 2 * Math.Pow(1024, 2)) 
                        {
                            byte[] b = new byte[customerDto.Image.Length];
                            customerDto.Image.OpenReadStream().Read(b, 0, b.Length);
                            customer.Image = b;
                        }
                    }
                }
                _dbContext.Update(customer);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
            //// Update address
            //var address = customerEntity.Address ?? new Address();
            //address.Street = customerDto.Street;
            //address.PostalCode = customerDto.PostalCode;
            //address.CityId = customerDto.CityId;

            //// Save changes to the database
            //await _customerRepository.Update(customerEntity, cancellationToken);
            //if (address.Id == 0)
            //{
            //    address.UserId = customerEntity.Id;
            //    await _addressRepository.Add(address, cancellationToken);
            //}
            //else
            //{
            //    await _addressRepository.Update(address, cancellationToken);
            //}

        }  
    }
}
