using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc ;
using OdeToFood.Data;

namespace OdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        ////IActionResult == it encapsulate what will happen next
        //render view component
        public IViewComponentResult Invoke() 
        {
            //how many members in restaurants
            var countOfRestaurants = _restaurantData.GetCountOfRestaurant();
            //return result which render the number of view with name
            return View( "/Pages/Shared/ViewComponents/RestaurantCount/Default.cshtml", countOfRestaurants);
        }
    }
}
