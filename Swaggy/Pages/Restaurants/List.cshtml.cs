using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Swaggy.Core;
using Swaggy.Data;

namespace Swaggy.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IConfiguration Config { get; }

        private readonly IRestaurant restaurantData;
        
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurant data)
        {
            Config = config;
            this.restaurantData = data;
        }

        public void OnGet()
        {
            Message = Config["message"];
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}
