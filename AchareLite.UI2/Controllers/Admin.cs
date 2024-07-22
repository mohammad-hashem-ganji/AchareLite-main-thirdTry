using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.Services;
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
        private readonly ICustomerAppService _customerAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly IExpertAppService _expertAppService;

        public Admin(IOrderAppService orderAppService, IServiceAppService serviceAppService, ICustomerAppService customerAppService, ICommentAppService commentAppService, IExpertService expertService, IExpertAppService expertAppService)
        {
            _orderAppService = orderAppService;
            _customerAppService = customerAppService;
            _commentAppService = commentAppService;
            _expertAppService = expertAppService;
        }
        public async Task<IActionResult> ShowPendingOrders(CancellationToken cancellationToken)
        {
            ViewData["orders"] = await _orderAppService.ShowOrderInDifferentStatus((int)Status.Pending, cancellationToken);
            return View();
        }
        public async Task<IActionResult> ShowOrdersInProgress(CancellationToken cancellationToken)
        {
            ViewData["orders"] = await _orderAppService.ShowOrderInDifferentStatus((int)Status.InProgress, cancellationToken);
            return View();
        }
        public async Task<IActionResult> ShowCompletedOrders(CancellationToken cancellationToken)
        {
            ViewData["orders"] = await _orderAppService.ShowOrderInDifferentStatus((int)Status.Completed, cancellationToken);
            return View();
        }
        public async Task<IActionResult> ChangeOrderStatus(int orderId, int NewStatus, CancellationToken cancellationToken)
        {
            (OrderDto?, bool) order = await _orderAppService.GetById(orderId, cancellationToken);
            if (order.Item2 != false)
            {
                order.Item1!.StatusId = NewStatus;
                bool result = await _orderAppService.Update(order.Item1, cancellationToken);
                if (result)
                {
                    return RedirectToAction("ShowOrders", "Admin");
                }
            }
            return RedirectToAction("ShowOrders", "Admin");
        }
        public async Task<IActionResult> ShowUnacceptedComments(CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await _commentAppService.GetUnacceptedComments(cancellationToken);
            ViewData["comments"] = comments;
            return View();
        }
        public async Task<IActionResult> AcceptComment(int id, CancellationToken cancellationToken)
        {
            var comment = await _commentAppService.GetById(id, cancellationToken);
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid comment ID.";
                return RedirectToAction("Error");
            }
            if (comment.Item2)
            {
                comment.Item1.IsAccept = true;
                await _commentAppService.Update(comment.Item1, cancellationToken);
                return RedirectToAction("ShowUnacceptedComments", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "کامنت پیدا نشد";
                return RedirectToAction("Error");
                //return NotFound("Comment not found or could not be accepted.");
            }

        }
        public IActionResult Error()
        {
            // This view will show the error messages
            var errorMessage = TempData["ErrorMessage"] as string;
            var successMessage = TempData["SuccessMessage"] as string;
            ViewData["ErrorMessage"] = errorMessage;
            ViewData["SuccessMessage"] = successMessage;
            return View();
        }
    }
}



