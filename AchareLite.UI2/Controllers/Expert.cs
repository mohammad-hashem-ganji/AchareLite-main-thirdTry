﻿using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Expert : Controller
    {
        private readonly IExpertAppService _expertAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly IBidAppService _bidAppService;

        public Expert(IExpertAppService expertAppService, IServiceAppService serviceAppService, IOrderAppService orderAppService, IBidAppService bidAppService)
        {
            _expertAppService = expertAppService;
            _serviceAppService = serviceAppService;
            _orderAppService = orderAppService;
            _bidAppService = bidAppService;
        }
        public ExpertProfileViewModel InputModel { get; set; }
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
                var matchingOrders = orders.Where(o => expert.ServiceIds.Contains(o.ServiseId)).ToList();
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
            List<BidDto> expertBids = await _bidAppService.GetAll(expertId, cancellationToken);
            List<BidDto> acceptedBids = expertBids.Where(bid => bid.StatusId == 1).ToList();
            List<OrderDto> allOrders = await _orderAppService.GetAll(cancellationToken);
            List<OrderDto> ordersForExpert = allOrders
                .Where(order => acceptedBids.Any(bid => bid.OrderId == order.Id))
                .ToList();
            ViewData["acceptedBids"] = acceptedBids;
            ViewData["ordersForExpert"] = ordersForExpert;
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
