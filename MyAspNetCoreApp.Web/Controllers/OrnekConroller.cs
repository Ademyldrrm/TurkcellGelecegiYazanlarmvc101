using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekConroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
