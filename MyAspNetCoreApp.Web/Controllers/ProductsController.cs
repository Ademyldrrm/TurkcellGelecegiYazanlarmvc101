using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private IHelper _helper;

        private readonly ProductRepository _productRepository;


        public ProductsController(AppDbContext context, IHelper helper)
        {


            _productRepository = new ProductRepository();
            _helper= helper;
            _context=context;


        }
        public IActionResult Index([FromServices] IHelper helper2)
        {

            var text = "As.Net";
            var uppertext = _helper.Upper(text);

            var status = _helper.Equals(helper2);

            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) _ = _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProdut(Product product)
        {
            //1.Yöntem

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();


            //2. Yöntem methot şeklinde string ame  şeklinde .....
            //Product product = new Product(){Name = Name,Price = Price,Stock = Stock,Color = Color};

            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["Status"] = "Ürün  Başarıyla Eklendi";
            return RedirectToAction("Index");
           
        }

        public IActionResult Update(int id)
        {
            var products = _context.Products.Find(id);

            return View(products);
        }
        [HttpPost]
        public IActionResult Update(Product product,int productıd)
        {
            product.Id = productıd;
            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["Status"] = "Ürün Başarıyla Güncellendi";
            return RedirectToAction("Index");
        }
    }

}
