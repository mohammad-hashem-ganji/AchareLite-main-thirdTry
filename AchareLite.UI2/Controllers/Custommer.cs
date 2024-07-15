using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles = "Customer")]
    public class Custommer : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public Custommer(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public async Task<IActionResult> ShowCustomerProfile(CancellationToken cancellationToken)
        {
            var customerIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userCustomerId")?.Value;
            if (string.IsNullOrEmpty(customerIdClaim) || !int.TryParse(customerIdClaim, out var customerId))
            {
                return View("NotFound");
            }
            else
            {
                var customer = await _customerAppService.GetById(customerId, cancellationToken);
                if (customer == null)
                {
                    return View("NotFound");
                }
                else
                {
                    ViewData["ExistingImageBase64"] = customer.ExistingImageBase64;
                    return View(customer);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            if (customerDto != null)
            {
                var updated = await _customerAppService.Update(customerDto, cancellationToken);
                if (updated)
                {
                    return RedirectToAction("ShowCustomerProfile", "Custommer");
                }
            }
            return RedirectToAction("ShowCustomerProfile", "Custommer");
        }
    }
}
