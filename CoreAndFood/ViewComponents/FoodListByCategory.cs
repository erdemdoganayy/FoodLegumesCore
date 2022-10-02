using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class FoodListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
           
            FoodRepository foodRepository = new FoodRepository();
            var FoodList = foodRepository.List(x => x.CategoryID == id);
            return View(FoodList);
        }
    }
}
