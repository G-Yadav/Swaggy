using Microsoft.EntityFrameworkCore;
using Swaggy.Core;
using System.Collections.Generic;
using System.Linq;

namespace Swaggy.Data
{
    public class SqlRestaurantData : IRestaurant
    {
        private readonly DBContextForSwaggy _db;

        public SqlRestaurantData(DBContextForSwaggy db)
        {
            _db = db;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            return restaurant;
        }

        public int commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
            }
            return restaurant; 
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return _db.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            // Its all been done in database
            var query = from r in _db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
