using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AchareLiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Service : ControllerBase
    {
        private readonly IServiceAppService _serviceAppService;

        public Service(IServiceAppService serviceAppService)
        {
            _serviceAppService = serviceAppService;
        }
        [HttpGet]
        [Route(nameof(ShowListOfServices))]
        public async Task<List<ServiceDto>> ShowListOfServices(CancellationToken cancellationToken)
        {
            List<ServiceDto> serviceDtos = await _serviceAppService.GetAll(cancellationToken);
            return serviceDtos;
        }
    }
}
