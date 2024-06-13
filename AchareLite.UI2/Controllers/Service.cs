using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Service : Controller
    {
        private readonly IServiceAppService _serviceAppService;

        public Service(IServiceAppService serviceAppService)
        {
            _serviceAppService = serviceAppService;
        }
        public async Task<IActionResult> ShowListOfServices(CancellationToken cancellationToken)
        {
            List<ServiceDto> serviceDtos = await _serviceAppService.GetAll(cancellationToken);
            ViewData["Services"] = serviceDtos;
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> ShowListOfServicesWithSubcategoryId(CancellationToken cancellationToken, int id =0)
        {
            if (id > 0)
            {
                List<ServiceDto> serviceDtos = await _serviceAppService.ShowListOfServicesWithSubCategoryId(id, cancellationToken);
                ViewData["serviceDtos"] = serviceDtos;
                TempData["subCategoryId"] = id;
            }
            return View();
        }
    }
}
