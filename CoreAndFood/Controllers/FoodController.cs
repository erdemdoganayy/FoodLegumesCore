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
        public IActionResult FoodDelete(int Id)
        {
            foodRepository.TDelete(new Food { Id = Id});
            return RedirectToAction("Index", "Food");
        }
        public IActionResult FoodGet(int Id)
        {
            var FoodInfo = foodRepository.TGet(Id);
            Food food = new Food()
            {
                Id = Id,
                Name = FoodInfo.Name,
                CategoryID = FoodInfo.CategoryID,
                Description = FoodInfo.Description,
                ImageUrl = FoodInfo.ImageUrl,
                Price = FoodInfo.Price,
                Stock = FoodInfo.Stock
            };
            ViewBag.FoodCategory = categoryRepository.TList();
            return View(FoodInfo);
        }
    }
}
