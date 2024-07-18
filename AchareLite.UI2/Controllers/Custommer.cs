using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles = "Customer")]
    public class Custommer : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IBidAppService _bidAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly ICommentAppService _commentAppService;

        public Custommer(ICustomerAppService customerAppService, IBidAppService bidAppService, IOrderAppService orderAppService, ICommentAppService commentAppService)
        {
            _customerAppService = customerAppService;
            _bidAppService = bidAppService;
            _orderAppService = orderAppService;
            _commentAppService = commentAppService;
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
        public async Task<IActionResult> GetBidsByOrderId(int orderId, CancellationToken cancellationToken)
        {
            if (orderId <= 0)
            {
                return BadRequest("Invalid order ID.");
            }
            List<BidDto> bidsOfOrder = await _bidAppService.GetBidsByOrderId(orderId, (int)Status.WaitingForCustomer, cancellationToken);
            if (bidsOfOrder == null || !bidsOfOrder.Any())
            {
                return NotFound();
            }
            return View(bidsOfOrder);
        }
        public async Task<IActionResult> AcceptBid(int bidId, CancellationToken cancellationToken)
        {
            var bid = await _bidAppService.GetById(bidId, cancellationToken);

            if (bid.Item2 == false)
            {
                // Log the issue for debugging purposes
                //_logger.LogWarning($"Bid with ID {bidId} not found.");

                // Return a user-friendly error message
                TempData["ErrorMessage"] = "The bid you are trying to accept does not exist.";
                return RedirectToAction("GetBidsByOrderId", "Custommer", new { orderId = bid.Item1.OrderId, cancellationToken });
            }
            bid.Item1.StatusId = (int)Status.accepted;
            await _bidAppService.Update(bid.Item1, cancellationToken);

            // Update all other bids for the same order to unAccepted
            var otherBids = await _bidAppService
                .GetBidsByOrderId(bid.Item1.OrderId, (int)Status.WaitingForCustomer, cancellationToken);
            foreach (var otherBid in otherBids)
            {
                if (otherBid.Id != bidId)
                {
                    otherBid.StatusId = (int)Status.unAccepted;
                    await _bidAppService.Update(otherBid, cancellationToken);
                }
            }
            var order = await _orderAppService.GetById(bid.Item1.OrderId, cancellationToken);
            if (order.Item2 != false)
            {
                order.Item1.StatusId = (int)Status.InProgress;
                await _orderAppService.Update(order.Item1, cancellationToken);
            }
            return RedirectToAction("GetBidsByOrderId", "Custommer", new { orderId = bid.Item1.OrderId,cancellationToken });
        }
        public async Task<IActionResult> ShowListOfOrdersAccepteBid(int customerId, CancellationToken cancellationToken)
        {
            // Get orders where the customer has accepted a bid
            List<OrderDto> orders = await _orderAppService.GetOrdersAcceptedBids(customerId, cancellationToken);

            ViewData["orders"] = orders;
            return View();
        }
        public async Task<IActionResult> AddComment(CommentDto model, CancellationToken cancellationToken)
        {
            if (model != null)
            {
                var commentDto = new CommentDto
                {
                    Text = model.Text,
                    Score = model.Score,
                    ExpertId = model.ExpertId,
                    CustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId")?.Value),
                    IsAccept = true
                };
                await _commentAppService.Create(commentDto, cancellationToken);
                return RedirectToAction("ShowAcceptedOrders", new { customerId = commentDto.CustomerId });
            }
            else
            {
                return RedirectToAction("ShowAcceptedOrders", new { customerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId")?.Value) });
            }            
        }

    }
}
