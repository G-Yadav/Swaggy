using Swaggy.Core;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Swaggy.Data
{
    public class InMemoryDatabase : IRestaurant
    {
        List<Restaurant> restaurants;

        public InMemoryDatabase()
        {
            this.restaurants = new List<Restaurant>
            { 
                new Restaurant {Id=1, Name="Indian", Location= "India", CuisineType=Cuisine.Indian},
                new Restaurant {Id=2, Name="Dorito", Location="Mexico", CuisineType=Cuisine.Mexican}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
