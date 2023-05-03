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

        public RestaurantAPIResult GetRestaurants(string zipCode, int page)
        {
           
            string key = File.ReadAllText("appsettings.json");
            string APIKey = JObject.Parse(key).GetValue("APIKey").ToString();

            var client = new RestClient($"https://restaurants-near-me-usa.p.rapidapi.com/restaurants/location/zipcode/{zipCode}/{page}");

            var request = new RestRequest();
            request.AddHeader("content-type", "application/octet-stream");
            request.AddHeader("X-RapidAPI-Key", $"{APIKey}");
            request.AddHeader("X-RapidAPI-Host", "restaurants-near-me-usa.p.rapidapi.com");
            
            var response = client.Get(request);

            try
            {
                var restaurants = new List<RestaurantMVC>();
                var results = JObject.Parse(response.Content).ToObject<RestaurantAPIResult>();

                return results;
            }
            catch (Exception)
            {

            }

            return new RestaurantAPIResult();

        }

    }
}

