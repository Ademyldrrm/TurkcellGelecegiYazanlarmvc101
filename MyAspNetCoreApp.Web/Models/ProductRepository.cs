namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "Kalem1", Price = 100, Stock = 50 },
            new() { Id = 2, Name = "Kalem2", Price = 200, Stock = 60 },
            new () { Id = 3, Name = "Kalem3", Price = 300, Stock = 70 },
            new () { Id = 4, Name = "Kalem4", Price = 400, Stock = 80 },
    }; 

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);
       

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})ye sahip ürün bulunmamaktadır");
            }

            _products.Remove(hasProduct);
        }

        public void Update(Product upProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == upProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({upProduct.Id})ye sahip ürün bulunmamaktadır");
            }

            _ = hasProduct.Name == upProduct.Name;
            _ = hasProduct.Price == upProduct.Price;
            _ = hasProduct.Stock == upProduct.Stock;
            var index = _products.FindIndex(x => x.Id == upProduct.Id);
            _products[index] = hasProduct;

        }

    }
}
