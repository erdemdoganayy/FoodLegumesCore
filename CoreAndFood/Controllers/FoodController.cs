using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page,4));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            var result = categoryRepository.TList();
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
            foodRepository.TDelete(new Food { Id = Id });
            return RedirectToAction("Index", "Food");
        }
        public IActionResult FoodGet(int Id)
        {

            List<SelectListItem> FoodCategory = (from x in categoryRepository.TList().Where(x => x.Status == true)
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();


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
            ViewBag.FoodCategory = FoodCategory;
            return View(FoodInfo);
        }

        public IActionResult FoodUpdate(Food food)
        {
            foodRepository.TUpdate(food);
            return RedirectToAction("Index","Food");
        }
    }
}
