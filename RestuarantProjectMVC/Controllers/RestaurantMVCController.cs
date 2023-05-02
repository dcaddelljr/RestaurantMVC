using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestuarantProjectMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestuarantProjectMVC.Controllers
{
    public class RestaurantMVCController : Controller
    {

        private readonly IRestaurantMVCRepository repo;
        private RestaurantMVC restaurant;

        // GET: /<controller>/

        public RestaurantMVCController(IRestaurantMVCRepository restaurantMVC)
        {
            repo = restaurantMVC;
        }
        
        public IActionResult Index(string zipCode)
        {
            var restaurant = new RestaurantMVC();

            if (zipCode == null)
            {
                return View(restaurant);
            }
            try
            {
                restaurant = repo.GetRestaurant(zipCode);
            }
            catch (AggregateException)
            {
                //return RedirectToAction("Index", "Weather");
            }

            return View(restaurant);
        }
       
        public IActionResult RestuarantMVC(string zipCode)
        {
            var restaruant = new RestaurantMVC();

            if (zipCode == null)
            {
                return View(restaruant);
            }

            try
            {
                restaurant = repo.GetRestaurant(zipCode);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Restaurant");
            }
            restaruant = repo.GetRestaurant(zipCode);

            ViewBag.Restaurant = GetRestaurant();
            return View();
        }

        private dynamic GetRestaurant()
        {
            throw new NotImplementedException();
        }
    }
}

