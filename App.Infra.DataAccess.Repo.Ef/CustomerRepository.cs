using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Entities;
using App.Domain.Core.OrderAgg.Entities;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(AchareDbContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<CustomerDto> GetById(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Attempting to retrieve customer with ID {customerId}");
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
                if (customer == null)
                {
                    _logger.LogWarning($"Customer with ID {customerId} not found.");
                    return null!;
                }
                _logger.LogInformation($"Customer with ID {customerId} retrieved successfully.");
                if (customer?.ImageData != null)
                {
                    _logger.LogDebug("Converting ImageData to Base64 string.");
                    customer.ExistingImageBase64 = Convert.ToBase64String(customer.ImageData);
                }
                return (customer == null) ? null! : customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting customer with ID {customerId}.");
                throw;
            }

        }
        public async Task<bool> Update(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Attempting to update customer with ID {customerDto.Id}");
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
                                _logger.LogDebug($"Adding order with ID {order.Id} to customer {customer.Id}");
                                customer.Orders.Add(order);
                            }
                            else
                            {
                                _logger.LogWarning($"Order with ID {customerId} not found for association with customer {customer.Id}.");
                            }
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"Customer with ID {customerDto.Id} not found for update.");
                        return false;
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
                                _logger.LogDebug("Updated customer image.");
                            }
                            else
                            {
                                _logger.LogWarning("Image size exceeds allowed limit.");
                            }
                        }
                        else
                        {
                            _logger.LogWarning("Invalid image format. Only JPG and PNG allowed.");
                        }
                    }
                    _dbContext.Update(customer);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInformation($"Customer with ID {customerDto.Id} updated successfully.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating customer with ID {customerDto.Id}.");
                throw;
            }



        }
    }
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
