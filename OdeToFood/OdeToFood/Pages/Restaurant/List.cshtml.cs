using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;

        private readonly IRestaurantData _restaurantData;
        /////////
        private readonly ILogger<ListModel> _logger;
        public IEnumerable<Core.Restaurant> Restaurants { get; set; }
        public string  Message { get; set; }
        public string Kranshy { get; set; }
        /// <summary>
        /// instead of use parameter searchTerm
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config,
            IRestaurantData restaurantData,ILogger<ListModel> logger)
        {
            _config = config;
            _restaurantData = restaurantData;
            ////////////////
            _logger = logger;
        }
        public void OnGet( )
        {
            ///////////to display message when executing in debug-> window->output
            /// Restaurant/List
            _logger.LogError("Executing Model List");
            /// ////////
            Message = _config["Message"];
            //Restaurants = _restaurantData.GetAll();
            
            /////////////
            //Binfding Model and retrieve info.
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);

        }
    }
}
