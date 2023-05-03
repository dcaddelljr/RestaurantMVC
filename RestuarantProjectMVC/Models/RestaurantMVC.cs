using System.Collections.Generic;
using System.Data;
using System;
using Microsoft.AspNetCore.Mvc;

namespace RestuarantProjectMVC.Models
{
    public class RestaurantMVC
    {
        public string restaurantName { get; set; }
        public string address { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public string stateName { get; set; }
        public string cityName { get; set; }
        public string hoursInterval { get; set; }
        
    }

    public class RestaurantAPIResult
    {
        public int matching_results { get; set; }
        public List<RestaurantMVC> restaurants { get; set; }
    }
}


