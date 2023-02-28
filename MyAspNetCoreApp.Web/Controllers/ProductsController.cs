using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly ProductRepository _productRepository;


        public ProductsController(AppDbContext context)
        {
            _productRepository = new ProductRepository();



            _context=context;

            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "Kalem1", Price = 100, Stock = 150,Color = "Red"});
            //    _context.Products.Add(new Product() { Name = "Kalem2", Price = 200, Stock = 250,Color = "White"});
            //    _context.Products.Add(new Product() { Name = "Kalem3", Price = 300, Stock = 350,Color = "Red"});
            //    _context.Products.Add(new Product() { Name = "Kalem4", Price = 400, Stock = 450 , Color = "Red" });
            //    _context.SaveChanges();
            //}

           


        }
        public IActionResult Index()
        {
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
        public IActionResult AddProdut(string Name,decimal Price,int Stock,string Color)
        {
            //1.Yöntem

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            Product product = new Product(){Name = Name,Price = Price,Stock = Stock,Color = Color};

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
