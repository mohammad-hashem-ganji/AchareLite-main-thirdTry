using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Custommer : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public Custommer(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public async Task<IActionResult> ShowCustomerProfile(CancellationToken cancellationToken)
        {
            var customerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
            var customer = await _customerAppService.GetById(customerId, cancellationToken);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            if (customerDto != null)
            {
                var updated = await _customerAppService.Update(customerDto, cancellationToken);
                if (updated)
                {
                    return RedirectToAction("ShowCustomerProfile", "Customer");
                }
            }
            return RedirectToAction("ShowCustomerProfile", "Customer");
        }
    }
}
