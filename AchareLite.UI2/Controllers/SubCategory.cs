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


        public IActionResult ShowListOfSubCategories()
        {
            var SubCategoryEntities = _subCategoryAppService.GetAll();
            ViewData["SubCategories"] = SubCategoryEntities;
            return View();
        }
        public IActionResult Create() => View();
        public async Task<IActionResult> CreateConfirm(string name, int mainCategoryId)
        {
            _subCategoryAppService.Creat(name, mainCategoryId);
            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            _subCategoryAppService.Delete(id);
            return RedirectToAction("ShowListOfSubCategories");
        }
        public IActionResult Edit(int id)
        {
            var subDto = _subCategoryAppService.Edit(id);
            ViewData["subCategoryEntity"] = subDto;
            return View();
        }
        public IActionResult Update(SubCategoryDto subCategoryDto)
        {
            _subCategoryAppService.Update(subCategoryDto);
            return RedirectToAction("ShowListOfSubCategories");
        }

    }
}
