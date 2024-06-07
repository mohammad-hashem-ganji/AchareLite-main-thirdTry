using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.Member.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AchareList.UI.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public string CategoryName { get; set; }
        [BindProperty]
        public int Count { get; set; }
        [BindProperty]
        public List<MainCategory> categories { get; set; }

        public void OnGet()
        {
            categories = _categoryRepository.GetAll();
        }

        public IActionResult OnGetDelete(int id)
        {
           
            return RedirectToAction("Index");
        }

        public IActionResult OnPost()
        {
            
            return RedirectToAction("Index");
        }
    }
}
