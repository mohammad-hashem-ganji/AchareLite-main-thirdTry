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
        public async Task<IActionResult> Create()
        {
            ViewData["subCategoryId"] = (int)TempData["subCategoryId"];
            return View();
        }
        public async Task<IActionResult> CreateConfirm(ServiceDto serviceDto, CancellationToken cancellationToken)
        {
            await _serviceAppService.Create(serviceDto.Title, serviceDto.SubCategoryId, cancellationToken);
            return RedirectToAction("ShowListOfServicesWithSubcategoryId", "Service", new { cancellationToken, id = serviceDto.SubCategoryId });
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _serviceAppService.Delete(id, cancellationToken);
            return RedirectToAction("ShowListOfServicesWithSubcategoryId", "Service");
        }
        public async Task<IActionResult> Edit(int id , CancellationToken cancellationToken)
        {
            (ServiceDto?, bool) serviceDto = await _serviceAppService.GetById(id, cancellationToken);
            ViewData["serviceDto"] = serviceDto.Item1;
            return View();
        }
        public async Task<IActionResult> Update(ServiceDto serviceDto,CancellationToken cancellationToken)
        {
            await _serviceAppService.Update(serviceDto, cancellationToken);
            return RedirectToAction("ShowListOfServicesWithSubcategoryId", "Service", new { cancellationToken, id = serviceDto.SubCategoryId });
        }
    }
}
