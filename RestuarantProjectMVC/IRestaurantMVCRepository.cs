using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using RestuarantProjectMVC.Models;

namespace RestuarantProjectMVC
{
	public interface IRestaurantMVCRepository
	{
       
        public RestaurantMVC GetRestaurant(string zipCode);
        RestaurantMVC GetRestaurant();
        public IEnumerable<RestaurantMVC> GetRestaurants();

    }
}

