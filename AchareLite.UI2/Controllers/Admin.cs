using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Admin : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly IExpertAppService _expertAppService;

        public Admin(IOrderAppService orderAppService, IServiceAppService serviceAppService, ICustomerAppService customerAppService, ICommentAppService commentAppService)
        {
            _orderAppService = orderAppService;
            _serviceAppService = serviceAppService;
            _customerAppService = customerAppService;
            _commentAppService = commentAppService;
        }
        public async Task<IActionResult> ShowPendingOrders(CancellationToken cancellationToken)
        {
            List<OrderDto> notCheckedOrdersStatus = new();
            notCheckedOrdersStatus = await _orderAppService.ShowOrderInDifferentStatus((int)Status.Pending, cancellationToken);
            ViewData["orders"] = notCheckedOrdersStatus;
            return View();
        }
        public async Task<IActionResult> ShowOrdersInProgress(CancellationToken cancellationToken)
        {
            List<OrderDto> inProgressOrdersStatus = new();
            inProgressOrdersStatus = await _orderAppService.ShowOrderInDifferentStatus((int)Status.InProgress, cancellationToken);
            ViewData["orders"] = inProgressOrdersStatus;
            return View();
        }
        public async Task<IActionResult> ShowCompletedOrders(CancellationToken cancellationToken)
        {
            List<OrderDto> CompleteOrdersStatus = new();
            CompleteOrdersStatus = await _orderAppService.ShowOrderInDifferentStatus((int)Status.Completed, cancellationToken);
            ViewData["orders"] = CompleteOrdersStatus;
            return View();
        }
        public async Task<IActionResult> ChangeOrderStatus(int orderId, int NewStatus, CancellationToken cancellationToken)
        {
            (OrderDto?, bool) order = await _orderAppService.GetById(orderId, cancellationToken);
            if (order.Item2 != false)
            {
                order.Item1.StatusId = NewStatus;
              bool result = await _orderAppService.Update(order.Item1, cancellationToken);
            }
            return RedirectToAction("ShowOrders", "Admin");
        }
        public async Task<IActionResult> ShowUnacceptedComments(CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await _commentAppService.GetUnacceptedComments(cancellationToken);
            foreach (var comment in comments)
            {
                comment.CustomerName = await _customerAppService.GetCustomerName(comment.CustomerId, cancellationToken);
                comment.ExpertName = await _expertAppService.GetExpertName(comment.ExpertId, cancellationToken);
            }
            ViewData["comments"] = comments;
            return View();
        }
    }
}



