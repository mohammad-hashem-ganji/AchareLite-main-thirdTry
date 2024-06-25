using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Order : Controller
    {
        private readonly IOrderAppService _orderAppService;
        public Order(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        public async Task<IActionResult> ShowListOfOrders(CancellationToken cancellationToken) => View();
        public async Task<IActionResult> Create() => View();
        public async Task<IActionResult> CreateConfirm(OrderDto order, CancellationToken cancellationToken)
        {

        }

    }
}
