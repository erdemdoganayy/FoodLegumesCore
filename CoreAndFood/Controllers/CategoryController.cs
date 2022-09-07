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
    }
}
