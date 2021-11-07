using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swaggy.Core;
using Swaggy.Data;

namespace Swaggy.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; private set; }
        public IRestaurant Restaurants { get; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurant restaurants)
        {
            Restaurants = restaurants;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = Restaurants.GetRestaurantById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
