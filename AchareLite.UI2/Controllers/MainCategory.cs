using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MainCategory : Controller
    {
        private readonly IMainCategoryAppService _mainCategoryAppService;

        public MainCategory(IMainCategoryAppService mainCategoryAppService)
        {
            _mainCategoryAppService = mainCategoryAppService;
        }
        
        public async Task< IActionResult> ShowListOfMainCategories(CancellationToken cancellationToken)
        {
            List<MainCategoryDto> mainCategories = await _mainCategoryAppService.GetAll(cancellationToken);
            ViewData["mainCategories"] = mainCategories;
            return View();
        }
        public async Task<IActionResult> Create() => View();
        public async Task<IActionResult> CreateConfirm(MainCategoryDto mainCategoryDto,CancellationToken cancellationToken)
        {
            await _mainCategoryAppService.Create(mainCategoryDto.Title, cancellationToken);
            return RedirectToAction("ShowListOfMainCategories", "MainCategory");
        }
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            await _mainCategoryAppService.Delete(id, cancellationToken);
            return RedirectToAction("ShowListOfMainCategories", "MainCategory");
        }
        public async Task<IActionResult> Edit(int id,CancellationToken cancellationToken)
        {
            (MainCategoryDto?, bool) mainDto = await _mainCategoryAppService.GetById(id, cancellationToken);
            ViewData["mainCategoryEntity"] = mainDto.Item1;
            return View();
        }
        public async Task<IActionResult> Update(MainCategoryDto mainCategoryDto,CancellationToken cancellationToken)
        {
            await _mainCategoryAppService.Update(mainCategoryDto, cancellationToken);
            return RedirectToAction("ShowListOfMainCategories");
        }

    }
}
