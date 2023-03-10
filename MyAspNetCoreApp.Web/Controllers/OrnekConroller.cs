using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string? Name2 { get; set; }
    }

    public class OrnekConroller : Controller
    {
        public IActionResult Index()
        {
            var productList = new List<Product2>()
            {
                new() { Id = 1, Name2 = "Tv" },
                new() { Id = 2, Name2 = "Kalem" }
            };
                


            //    ViewBag.name = "Asp.Net.Core";
            //    ViewData["Age"] = 30;
            //    ViewData["Name"] = new List<string>() { "Adem", "Ahmet", "Ali"};
            //    ViewBag.person = new { id = 1, Name = "Adem", Age = 22 };

            //ViewBag.name = "Adem";

            //TempData["surname"] = "Yıldız";

            return View(productList);
        }

        public IActionResult Index2()
        {
            
            return View();
            
        }

        public IActionResult Index3()
        {
            return RedirectToAction("Index", "OrnekConroller");
          
        }

        public IActionResult ParametreView(int id)

        {
            return RedirectToAction("JsonResultParametre", "OrnekConroller", new { id = id });
        }

        public IActionResult ContentResult()
        {
            return Content("Content Result");
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id=id });
        }

        public IActionResult EmpetyResult()
        {
            return new EmptyResult();
        }
    }
}
