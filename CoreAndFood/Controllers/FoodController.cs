using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            return View(foodRepository.TList("Category"));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
          var result =  categoryRepository.TList();
            return View(result);
        }
        [HttpPost]
        public IActionResult FoodAdd(Food food)
        {
            foodRepository.TAdd(food);
            return RedirectToAction("Index", "Food");
        }
    }
}
