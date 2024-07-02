﻿using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainCategoryAppService _mainCategoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IServiceAppService _serviceAppService;

        public HomeController(IMainCategoryAppService mainCategoryAppService, ISubCategoryAppService subCategoryAppService, IServiceAppService serviceAppService)
        {
            _mainCategoryAppService = mainCategoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
        }
        public async Task<IActionResult> ShowMainPage(CancellationToken cancellationToken)
        {
            List<MainCategoryDto> mainCategories = await _mainCategoryAppService.GetAll(cancellationToken);
            ViewData["mainCategories"] = mainCategories;
            ViewData["canellationToken"] = cancellationToken;
            return View();
        }
        public async Task<IActionResult> ShowSubCategories(CancellationToken cancellationToken, int id = 0)
        {
            //List<SubCategoryDto> subCategories = await _subCategoryAppService.ShowListOfSubCategoriesWhitMianCategoryId(id, cancellationToken);
            //ViewData["subCategories"] = subCategories;

            if (id > 0)
            {
                List<SubCategoryDto> subDtos = await _subCategoryAppService.ShowListOfSubCategoriesWhitMianCategoryId(id, cancellationToken);
                ViewData["subCategoryEntities"] = subDtos;
                TempData["mainCategoryId"] = id;
            }
            return View();
        }
        public async Task<IActionResult> showServices(CancellationToken cancellationToken, int id = 0)
        {
            List<ServiceDto> serviceDtos = await _serviceAppService.ShowListOfServicesWithSubCategoryId(id, cancellationToken);
            ViewData["serviceEntities"] = serviceDtos;
            return View();
        }
        public async Task<IActionResult> CheckRole(CancellationToken cancellationToken)
        {
            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("ShowMainPage", "Home");
            }
            else if (User.IsInRole("Expert"))
            {
                return RedirectToAction("ShowExpertPanel", "Expert");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("ShowOrders", "Admin");
            }
            else
            {
                return View();
            }
        }
    }
}
