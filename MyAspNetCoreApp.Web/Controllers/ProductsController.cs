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

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem1", Price = 100, Stock = 150});
                _context.Products.Add(new Product() { Name = "Kalem2", Price = 200, Stock = 250});
                _context.Products.Add(new Product() { Name = "Kalem3", Price = 300, Stock = 350});
                _context.Products.Add(new Product() { Name = "Kalem4", Price = 400, Stock = 450 });
                _context.SaveChanges();
            }

           


        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
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
        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
