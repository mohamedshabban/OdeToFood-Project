using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
namespace OdeToFood.Data
{
    //to store data into database
    public class OdeToFoodDbContext: DbContext
    {
        //i want code to pass in connection string and
        //other options this DbContext needs
        //to know about to work with database
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext>options):base(options)
        {
            
        }
        //To query and save instances of restaurant
        //insert,update,delete information from DB
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
