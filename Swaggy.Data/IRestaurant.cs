using Swaggy.Core;
using System.Collections.Generic;
using System.Text;

namespace Swaggy.Data
{
    public interface IRestaurant
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name=null);
    }
}
