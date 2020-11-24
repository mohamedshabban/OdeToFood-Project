using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;
        public  InMemoryRestaurantData()
        {

            restaurants=new List<Restaurant>
            {
                new Restaurant{Id=0,Name = "Italian's Pizza",Location = "Elkhanka",Cuisine=CuisineType.Italian},
                new Restaurant{Id=1,Name = "Mexican's Pizza",Location = "ElMarg",Cuisine=CuisineType.Mexican},
                new Restaurant{Id=2,Name = "Indian's Pizza",Location = "Ain Shams",Cuisine=CuisineType.Indian},
                new Restaurant{Id=3,Name = "None's Pizza",Location = "Cairo",Cuisine=CuisineType.None}

            };
        }
      
        //Search Function
        public IEnumerable<Restaurant> GetRestaurantByName(string name=null)
        {
            //Query
            return from r in restaurants
                where string.IsNullOrEmpty(name) ||
                      r.Name.StartsWith(name) || r.Name.Contains(name)
                select r;
        }
        //Retrieve Data Based on ID
        public Restaurant GetId(int id)
        {
            //return Single value
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        //Create new Restaurant
        public Restaurant AddOrCreate(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
                restaurant.Location = updatedRestaurant.Location;
            }

            return restaurant;
        }

        public Restaurant Delete(int Id)
        {
            var deletedRestaurant = restaurants.FirstOrDefault(r => r.Id==Id);
            if (deletedRestaurant.Id != null)
            {
                restaurants.Remove(deletedRestaurant);
            }

            return deletedRestaurant;
        }

        public int GetCountOfRestaurant()
        {
            return restaurants.Count();
        }

        public int Commit()
        {
            return 0;
        }
    }
}