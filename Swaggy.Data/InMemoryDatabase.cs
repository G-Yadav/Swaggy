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
                new Restaurant {Id=2, Name="Dorito", Location="Mexico", CuisineType=Cuisine.Mexican},
                new Restaurant {Id=3, Name="Tom's Pizza", Location="Italy", CuisineType=Cuisine.Italian}
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public int commit()
        {
            return 0;
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

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.CuisineType = updatedRestaurant.CuisineType;
            }
            return restaurant;
        }
    }
}
