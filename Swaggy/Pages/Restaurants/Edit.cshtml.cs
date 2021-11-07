using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swaggy.Core;
using Swaggy.Data;

namespace Swaggy.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        public int restaurantId { get; private set; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> cuisines { get; set; }

        public IRestaurant Restaurants { get; }
        public IHtmlHelper HtmlHelper { get; }
        public IHtmlHelper<EditModel> htmlHelper { get; private set; } 

        public EditModel(IRestaurant restaurants, IHtmlHelper htmlHelper)
        {
            Restaurants = restaurants;
            HtmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId) 
        {
            if(!restaurantId.HasValue)
            {
                Restaurant = new Restaurant();
            }
            else
            {
                this.restaurantId = restaurantId.Value;
                Restaurant = Restaurants.GetRestaurantById(restaurantId.Value);
            }
            //cuisines = new SelectList(Enum.GetValues(typeof(Cuisine)));
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            cuisines = HtmlHelper.GetEnumSelectList(typeof(Cuisine));
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                cuisines = HtmlHelper.GetEnumSelectList(typeof(Cuisine));
                return Page();
            }
            string message;
            if(Restaurant.Id > 0)
            {
                Restaurants.UpdateRestaurant(Restaurant);
                message = "Restaurant Updated Successfully";
            }
            else
            {
                Restaurant = Restaurants.Add(Restaurant);
                message = "Restaurant Added Successfully";
            }
            Restaurants.commit();
            TempData["Message"] = message;
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });

        }
    }
}
