using Swaggy.Core;
using System.Collections.Generic;
using System.Text;

namespace Swaggy.Data
{
    public interface IRestaurant
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name=null);
        Restaurant GetRestaurantById(int restaurantId);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        int commit();
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(int id);
    }
}
