using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    { 
       
       IEnumerable<Restaurant> GetRestaurantByName(string name);
       Restaurant GetId(int id);

       Restaurant AddOrCreate(Restaurant newRestaurant);
       //To Apply Updates
       Restaurant Update(Restaurant updatedRestaurant);
       Restaurant Delete(int Id);
       //Used in View Component
       int GetCountOfRestaurant();
       int Commit();

    }
}
