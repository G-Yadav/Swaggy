using Swaggy.Core;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Swaggy.Data
{
    public class InMemoryDatabase : IRestaurant
    {
        readonly List<Restaurant> restaurants;

        public InMemoryDatabase()
        {
            this.restaurants = new List<Restaurant>
            { 
                new Restaurant {Id=1, Name="Indian", Location= "India", CuisineType=Cuisine.Indian},
                new Restaurant {Id=2, Name="Dorito", Location="Mexico", CuisineType=Cuisine.Mexican}
            };
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurants.FirstOrDefault(r => r.Id.Equals(restaurantId));
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
