using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query= from r in _db.Restaurants
                where r.Name.Contains(name) || r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;
            return query;
        }

        public Restaurant GetId(int id)
        {
            return  _db.Restaurants.Find(id);
        }

        public Restaurant AddOrCreate(Restaurant newRestaurant)
        {
            _db.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            //Entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Delete(int Id)
        {
            var deletedRestaurant = GetId(Id);
            if (deletedRestaurant != null)
            {
                _db.Restaurants.Remove(deletedRestaurant);
            }

            return deletedRestaurant;
        }

        public int GetCountOfRestaurant()
        {
            return _db.Restaurants.Count();
        }

        public int Commit()
        {
            //return number of rows effected in database
            return _db.SaveChanges();
        }
    }
}