using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles = "Expert")]
    public class Expert : Controller
    {
        private readonly IExpertAppService _expertAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IOrderAppService _orderAppService;
        public Expert(IExpertAppService expertAppService, IServiceAppService serviceAppService, IOrderAppService orderAppService)
        {
            _expertAppService = expertAppService;
            _serviceAppService = serviceAppService;
            _orderAppService = orderAppService;
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
            var expert = await _expertAppService.GetById(int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value), cancellationToken);
            if (expert != null)
            {
                var availableServices = await _serviceAppService.GetAll(cancellationToken);
                var orders = await _orderAppService.GetAll(cancellationToken);
                var matchingOrders = orders.Where(o => expert.ServiceIds.Contains(o.ServiseId) && o.StatusId == (int)Status.Pending).ToList();
                ViewData["expert"] = expert;
                ViewData["availableServices"] = availableServices;
                ViewData["orders"] = matchingOrders;
                return View();
            }
            return NotFound(); // Handle case ******* ********** *****
        }
        public async Task<IActionResult> ShowAcceptedBids(CancellationToken cancellationToken)
        {
            int expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
            var acceptedBids = await _expertAppService
                .ShowBidInDifferentStatus(expertId, (int)Status.accepted, cancellationToken);
            ViewData["acceptedBids"] = acceptedBids.Item1;
            ViewData["ordersForExpert"] = acceptedBids.Item2;
            return View();
        }
        public async Task<IActionResult> ShowWaitingForCustomerBids(CancellationToken cancellationToken)
        {
            int expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
            var waitingForCustomerBids = await _expertAppService
                .ShowBidInDifferentStatus(expertId, (int)Status.WaitingForCustomer, cancellationToken);
            ViewData["waitingForCustomerBids"] = waitingForCustomerBids.Item1;
            ViewData["ordersForExpertWaitingForCustomer"] = waitingForCustomerBids.Item2;
            return View();
        }
        public async Task<IActionResult> UpdateExpertInformation(ExpertDto model, CancellationToken cancellationToken)
        {
            if (model != null)
            {
                var updated = await _expertAppService.Update(model, cancellationToken);
                if (updated)
                {
                    return RedirectToAction("ShowExpertProfile", "Expert"); 
                }
            }

            /*throw new Exception("Error updating expert profile");*/ // Handle errors appropriately
            return RedirectToAction("ShowExpertProfile", "Expert");
        }
        public async Task<IActionResult> UpdateExpertServices(List<int> selectedServiceIds, CancellationToken cancellationToken)
        {
            var expert = await _expertAppService.GetById(int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value), cancellationToken);
            if (expert != null)
            {
                expert.ServiceIds = selectedServiceIds;
                bool result = await _expertAppService.Update(expert, cancellationToken);
                if (result)
                {
                    return RedirectToAction("ShowExpertProfile", "Expert");
                }
            }
            return RedirectToAction("ShowExpertProfile", "Expert");
        }
    }
}
