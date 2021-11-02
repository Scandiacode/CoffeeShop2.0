using CoffeeShop2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddUser(CustomerModel u, string coffeeCheck)
        {
            if (coffeeCheck == "1")
            {
                u.HadCoffee = true;
            }
            else
            {
                u.HadCoffee = false;
            }
            using (CoffeeShopContext context = new CoffeeShopContext())
            {
                context.Customer.Add(u);
                context.SaveChanges();
            }
            return Redirect("/");
        }

        public IActionResult Result(CustomerModel One)
        {
            if (One.Password.ToLower() == "password")
            {
                return RedirectToAction("Form");
            }
            //ViewData["First Name"] = firstName;
            //ViewData["Last Name"] = lastName;
            return View(One);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
