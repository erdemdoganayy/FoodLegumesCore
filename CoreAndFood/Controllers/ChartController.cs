using CoreAndFood.Data.GoogleCharts;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Indexx()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProductList());
        }
        public List<Charts> ProductList()
        {
            // Statik veri
            //List<Charts> Cs = new List<Charts>();
            //Cs.Add(new Charts()
            //{
            //    productName = "Excalibur",
            //    stock = 25
            //});
            //Cs.Add(new Charts()
            //{
            //    productName = "HP",
            //    stock = 48
            //});
            //Cs.Add(new Charts()
            //{
            //    productName = "Altus",
            //    stock = 225
            //});

            List<Charts> chart = new List<Charts>();
            using (var db = new Context())
            {
                chart = db.Foods.ToList().Select(x => new Charts
                {
                    productName = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return chart;
        }

        public IActionResult Statistics()
        {
            Context db = new Context();

            var FruitID = db.Categories.Where(x => x.Name == "Fruits").Select(y => y.Id).FirstOrDefault();
            var VegetablesID = db.Categories.Where(x => x.Name == "Vegetables").Select(y => y.Id).FirstOrDefault();

            var TotalFood = db.Foods.Count();
            ViewBag.FoodTotal = TotalFood;
            var TotalCategory = db.Categories.Count();
            ViewBag.CategoryTotal = TotalCategory;
            var TotalFruits = db.Foods.Where(x => x.CategoryID == FruitID).Count();
            ViewBag.FruitsTotal = TotalFruits;
            var TotalVegetables = db.Foods.Where(x => x.CategoryID == VegetablesID).Count();
            ViewBag.VegetablesTotal = TotalVegetables;
            var TotalStocks = db.Foods.Sum(x => x.Stock);
            ViewBag.StocksTotal = TotalStocks;
            var TotalLegumes = db.Foods.Where(x => x.CategoryID == db.Categories.Where(y => y.Name == "Legumes").Select(z => z.Id).FirstOrDefault()).Count();
            ViewBag.LegumesTotal = TotalLegumes;
            var FoodStockMax = db.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.StockMax = FoodStockMax;
            var FoodStockMin = db.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.StockMin = FoodStockMin;
            var PriceAverage = db.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.PriceAvg = PriceAverage;
            var FruitsCount = db.Foods.Where(x => x.CategoryID == FruitID).Sum(y => y.Stock);
            ViewBag.CountFruits = FruitsCount;
            var VegetablesCount = db.Foods.Where(x => x.CategoryID == VegetablesID).Sum(y => y.Stock);
            ViewBag.CountVegetables = VegetablesCount;
            var MaxPrice = db.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.HighPrice = MaxPrice;
            return View();
        }
    }
}
