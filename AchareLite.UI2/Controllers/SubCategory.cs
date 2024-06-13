using App.Domain.AppServices;
using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class SubCategory : Controller
    {
        private readonly ISubCategoryAppService _subCategoryAppService;

        public SubCategory(ISubCategoryAppService subCategoryAppService)
        {
            _subCategoryAppService = subCategoryAppService;
        }
        public async Task<IActionResult> ShowListOfSubCategories(CancellationToken cancellationToken)
        {
            List<SubCategoryDto> SubCategoryDtos = await _subCategoryAppService.GetAll(cancellationToken);
            ViewData["SubCategories"] = SubCategoryDtos;
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewData["mainCategoryId"] = (int)TempData["mainCategoryId"] ;
            return View();
        }
        public async Task<IActionResult> CreateConfirm(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Create(subCategoryDto.Title,subCategoryDto.MainCategoryId, cancellationToken);
            return RedirectToAction("ShowListOfSubCategoriesWhitMianCategoryId", "SubCategory", new { cancellationToken, id = subCategoryDto.MainCategoryId });
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Delete(id, cancellationToken);
            return RedirectToAction("ShowListOfSubCategoriesWhitMianCategoryId", "SubCategory");
        }
        public async Task<IActionResult> ShowListOfSubCategoriesWhitMianCategoryId(CancellationToken cancellationToken, int id = 0)
        {
            if (id > 0)
            {
                List<SubCategoryDto> subDtos = await _subCategoryAppService.ShowListOfSubCategoriesWhitMianCategoryId(id, cancellationToken);
                ViewData["subCategoryEntities"] = subDtos;
                TempData["mainCategoryId"] = id;
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            (SubCategoryDto?, bool) subDto = await _subCategoryAppService.GetById(id, cancellationToken);
            ViewData["subCategoryEntity"] = subDto.Item1;
            return View();
        }
        public async Task<IActionResult> Update(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Update(subCategoryDto, cancellationToken);
            // ViewData["mainCategoryId"] = subCategoryDto.MainCategoryId;
            return RedirectToAction("ShowListOfSubCategoriesWhitMianCategoryId", "SubCategory", new { cancellationToken, id = subCategoryDto.MainCategoryId });
        }

    }
}
