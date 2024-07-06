using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.OrderAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Expert : Controller
    {
        private readonly IExpertAppService _expertAppService;

        public Expert(IExpertAppService expertAppService)
        {
            _expertAppService = expertAppService;
        }
        public class ExpertProfileViewModel
        {
            public ExpertDto Expert { get; set; }
            public List<ServiceDto> AvailableServices { get; set; }
            public List<int> SelectedServiceIds { get; set; } 
            public List<OrderDto> Orders { get; set; }
        }

        public async Task<IActionResult> ShowExpertProfile(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
            var expert = await _expertAppService.GetById(expertId, cancellationToken);
            if (expert != null)
            {
                var availableServices = await _expertAppService.GetAll(cancellationToken);


                var selectedServiceIds = expert.ServiceIds ?? new List<int>();
                var orders = await _expertAppService.GetOrdersByExpertSevices(expert.ServiceIds, cancellationToken); // Get orders matching expert's services
                var matchingOrders = orders.Where(o => expert.ServiceIds.Contains(o.ServiceId)).ToList();
                ViewData["expert"] = new ExpertProfileViewModel
                {
                    Expert = expert,
                    AvailableServices = availableServices,
                    SelectedServiceIds = selectedServiceIds,
                    Orders = orders
                };
                ViewData["availableServices"] = availableServices;
                ViewData["orders"] = matchingOrders; 
                return View();


                return View();
            }

            return NotFound(); // Handle case

        }
        public async Task<ExpertDto> UpdateExpert(ExpertDto model, CancellationToken cancellationToken)
        {
            if (model != null)
            {
                var updated = await _expertAppService.Update(model, cancellationToken);
                if (updated)
                {
                    return await _expertAppService.GetById(model.Id, cancellationToken); // Return the updated expert
                }
            }

            throw new Exception("Error updating expert profile"); // Handle errors appropriately
        }
    }
