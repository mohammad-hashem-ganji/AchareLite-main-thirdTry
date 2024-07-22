using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles = "Expert")]
    public class Bid : Controller
    {
        private readonly IBidAppService _bidAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly ICustomerAppService _customerAppService;
        //public ExpertServicePriceViewModel Input { get; set; }
        [BindProperties]
        public class ExpertServicePriceViewModel
        {
            [Required]
            public string Price { get; set; }
            [Required]
            public string? Description { get; set; }
            public string OrderTitle { get; set; }
            public int Bidid { get; set; }
            public int OrderId { get; set; }
            public int ExpertId { get; set; }
            public int CustomerId { get; set; }
            public string? CustomerName { get; set; }
            public int ServiceId { get; set; }
            public string? ServiceName { get; set; }
            public int StatusId { get; set; }

        }
        public Bid(IBidAppService bidAppService, IOrderAppService orderAppService, IServiceAppService serviceAppService, ICustomerAppService customerAppService)
        {
            _bidAppService = bidAppService;
            _orderAppService = orderAppService;
            _serviceAppService = serviceAppService;
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> Create(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderAppService.GetById(orderId, cancellationToken);
            var bidViewModel = new ExpertServicePriceViewModel
            {
                OrderId = order.Item1.Id,
                OrderTitle = order.Item1.Title,
                CustomerId = order.Item1.CustomerId,
                StatusId = order.Item1.StatusId,
                ExpertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value),
                ServiceId = order.Item1.ServiseId,
                ServiceName = await _serviceAppService.GetServiceName(order.Item1.ServiseId, cancellationToken),
                CustomerName = await _customerAppService.GetCustomerName(order.Item1.CustomerId, cancellationToken)
            };
            return View(bidViewModel);
        }
        public async Task<IActionResult> CreateConfirm(ExpertServicePriceViewModel viewModel, CancellationToken cancellationToken)
        {
            BidDto bid = new BidDto
            {
                ExpertId = viewModel.ExpertId,
                ExprtSujestFee = viewModel.Price,
                OrderId = viewModel.OrderId,
                StatusId = viewModel.StatusId,
            };
            await _bidAppService.Create(bid, cancellationToken);
            return RedirectToAction("ShowExpertProfile", "Expert");
        }
        public async Task<IActionResult> Edit(int bidId, CancellationToken cancellationToken)
        {
            (BidDto?, bool) bidDto = await _bidAppService.GetById(bidId, cancellationToken);
            var order = await _orderAppService.GetById(bidDto.Item1.OrderId, cancellationToken);
            ViewData["editBidDto"] = new ExpertServicePriceViewModel
            {
                OrderId = order.Item1.Id,
                OrderTitle = order.Item1.Title,
                CustomerId = order.Item1.CustomerId,
                StatusId = order.Item1.StatusId,
                ExpertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value),
                ServiceId = order.Item1.ServiseId,
                ServiceName = order.Item1.ServiceName,
                CustomerName = order.Item1.CustomerName,
                Bidid = bidDto.Item1.Id,
                Description = bidDto.Item1.Description,
                Price = bidDto.Item1.ExprtSujestFee
            };
            return View();
        }
        public async Task<IActionResult> UpdateBid(ExpertServicePriceViewModel viewModel, CancellationToken cancellationToken)
        {
            BidDto bid = new BidDto
            {
                ExpertId = viewModel.ExpertId,
                ExprtSujestFee = viewModel.Price,
                OrderId = viewModel.OrderId,
                StatusId = viewModel.StatusId,
                Description = viewModel.Description
            };
            await _bidAppService.Update(bid, cancellationToken);
            return RedirectToAction("ShowExpertProfile", "Expert");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBid(int bidId, CancellationToken cancellationToken)
        {
            await _bidAppService.Delete(bidId, cancellationToken);
            return RedirectToAction("ShowExpertProfile", "Expert");
        }
    }
}
