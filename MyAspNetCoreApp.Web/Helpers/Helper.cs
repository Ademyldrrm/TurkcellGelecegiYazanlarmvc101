using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Helpers
{
    public class Helper:IHelper
    {
        
        //private bool _isConfiguration;

        //public Helper(bool isConfiguration)
        //{
        //    _isConfiguration = isConfiguration;
        //}

        private AppDbContext _appDbContext;


        public Helper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string Upper(string text)
        {

            _appDbContext.Products.ToList();

            return text.ToUpper();
        }
    }

    
}
