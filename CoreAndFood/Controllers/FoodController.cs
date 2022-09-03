using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            FoodRepository foodRepository = new FoodRepository();
            return View(foodRepository.TList());
        }
    }
}
