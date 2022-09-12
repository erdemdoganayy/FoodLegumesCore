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
    }
}
