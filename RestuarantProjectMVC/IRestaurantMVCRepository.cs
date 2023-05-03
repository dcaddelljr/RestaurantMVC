using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using RestuarantProjectMVC.Models;

namespace RestuarantProjectMVC
{
	public interface IRestaurantMVCRepository
	{
       
        //public RestaurantMVC GetRestaurants(string zipCode);
        
        public RestaurantAPIResult GetRestaurants(string zipCode, int page);

    }
}

