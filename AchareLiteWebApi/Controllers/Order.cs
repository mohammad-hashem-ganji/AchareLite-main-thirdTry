using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AchareLiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceAppService _serviceAppService;
        public Order(IOrderAppService orderAppService, IServiceAppService serviceAppService)
        {
            _orderAppService = orderAppService;
            _serviceAppService = serviceAppService;
        }
        [HttpGet]
        [Route(nameof(ShowListOfOrders))]
        public async Task<List<OrderDto>?> ShowListOfOrders(CancellationToken cancellationToken)
        {
            List<OrderDto>? orders = new();
            orders = await _orderAppService.GetAll(cancellationToken);
            return (orders == null) ? null : orders;
        }
    }
}
