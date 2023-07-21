using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();
            myProduct.Name = "Kajak";
            string productName = myProduct.Name;
            return View("Result",(object)String.Format("Nazwa produktu: {0}",productName));
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return UseExtensionEnumerable();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ViewResult CreateProduct()
        {
            Product myProduct = new Product {
                ProductID = 100,
         Name = "Kajak",
            Description = "Łódka jednoosobowa",
           Price = 275M,
       Category = "Sporty wodne"
        };
           
            return View("Result",(object)String.Format("Kategoria: {0}",myProduct.Category));
        }
        public ViewResult CreateCollection()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
              {
                  new Product {Name = "Kajak",Price = 275M },
                  new Product {Name = "Kamizelka ratunkowa",Price = 48.95M },
                  new Product {Name = "Piłka nożna",Price = 19.50M },
                  new Product {Name = "Flaga narożna",Price = 34.95M }
              }
          };
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Razem: {0:c}",cartTotal));
        }
        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
              {
                  new Product {Name = "Kajak",Category = "Sporty wodne",Price = 275M },
                  new Product {Name = "Kamizelka ratunkowa",Category = "Sporty wodne",Price = 48.95M },
                  new Product {Name = "Piłka nożna",Category = "Piłka nożna",Price = 19.50M },
                  new Product {Name = "Flaga narożna",Category = "Piłka nożna",Price = 34.95M }
              }
            };

            decimal total = 0;
            foreach (Product prod  in products.Filter(prod => prod.Category == "Piłka nożna" || prod.Price > 20))
            {
                total += prod.Price;
            }
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();
            return View("Result", (object)String.Format("Razem: {0}", total));
        }
    }
        

    }
