using System;
using System.IO;
using System.Net.Http;
using System.Reflection.Emit;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestuarantProjectMVC.Controllers;
using RestuarantProjectMVC.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text.Json;
using System.Linq;

namespace RestuarantProjectMVC
{
    public class RestaurantMVCRepository : IRestaurantMVCRepository
	{
        private readonly string _conn;

        public RestaurantMVCRepository(string conn)
		{
			_conn = conn;
		}

        public RestaurantMVC GetRestaurant(string zipCode)
        {
            //{restaurantName = "", address = "", zipCode = "", hoursInterval = "", phone = "", cityName = "", stateName = ""}
            var restaurant = new RestaurantMVC() ;

            string key = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            var client = new RestClient($"https://restaurants-near-me-usa.p.rapidapi.com/restaurants/location/zipcode/{zipCode}/0");

            var request = new RestRequest();
            //var zipcode = new Zipcode();
            request.AddHeader("content-type", "application/octet-stream");
            request.AddHeader("X-RapidAPI-Key", $"{APIKey}");
            request.AddHeader("X-RapidAPI-Host", "restaurants-near-me-usa.p.rapidapi.com");
            //request.AddParameter("restaurantName", "1");
            var response = client.Get(request);

            //var restaurant = JsonConvert.DeserializeObject<RestaurantMVC>(key);
           
                restaurant.restaurantName = JObject.Parse(response.Content)["restaurants"][0]["restaurantName"].ToString();
                restaurant.address = JObject.Parse(response.Content)["restaurants"][0]["address"].ToString();
                restaurant.zipCode = JObject.Parse(response.Content)["restaurants"][0]["zipCode"].ToString();
                restaurant.hoursInterval = JObject.Parse(response.Content)["restaurants"][0]["hoursInterval"].ToString();
                restaurant.phone = JObject.Parse(response.Content)["restaurants"][0]["phone"].ToString();
                restaurant.cityName = JObject.Parse(response.Content)["restaurants"][0]["cityName"].ToString();
                restaurant.stateName = JObject.Parse(response.Content)["restaurants"][0]["stateName"].ToString();
                //restaurant.restaurantName = response.ToString();
                return restaurant;
        }

        public RestaurantMVC GetRestaurant()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RestaurantMVC> GetRestaurants()
        {
            throw new NotImplementedException();
        }
    }
}

