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
            var SubCategoryEntities = await _subCategoryAppService.GetAll(cancellationToken);
            ViewData["SubCategories"] = SubCategoryEntities;
            return View();
        }
        public async Task<IActionResult> Create() => View();
        public async Task<IActionResult> CreateConfirm(string name, int mainCategoryId, CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Create(name, mainCategoryId, cancellationToken);
            return RedirectToAction("Create", "SubCategory");
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _subCategoryAppService.Delete(id, cancellationToken);
            return RedirectToAction("ShowListOfSubCategories", "SubCategory");
        }
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            (SubCategoryDto?, bool) subDto = await _subCategoryAppService.GetById(id, cancellationToken);
            ViewData["subCategoryEntity"] = subDto;
            return View();
        }
        public async Task<IActionResult> Update(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            _subCategoryAppService.Update(subCategoryDto, cancellationToken);
            return RedirectToAction("ShowListOfSubCategories", "SubCategory");
        }

    }
}
