using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (string.IsNullOrEmpty(category.Name) && string.IsNullOrEmpty(category.Description))
            {
                TempData["ErrorMessage"] = "error";
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index", "Category");
        }
        public IActionResult CategoryGet(int Id)
        {
            var CategoryInfo = categoryRepository.TGet(Id);
            Category category = new Category()
            {
                Id = Id,
                Name = CategoryInfo.Name,
                Description = CategoryInfo.Description
            };
            return View(category);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            categoryRepository.TUpdate(category);
            return RedirectToAction("Index", "Category");
        }
        public IActionResult CategoryDelete(int Id)
        {
            var CategoryInfo = categoryRepository.TGet(Id);
            CategoryInfo.Status = false;
            categoryRepository.TUpdate(CategoryInfo);
            return RedirectToAction("Index", "Category");
        }
    }
}
