using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;


namespace OdeToFood.Pages.Restaurant
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        //To Show Message after add restaurant
        [TempData]
        public string Message { get; set; }
        public Core.Restaurant Restaurant { get; set; }

        //Show a Specific Details of Restaurant
        public DetailsModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        //Detail Page need to Know 
        //The ID of Restaurant to detail
        public IActionResult OnGet(int restaurantId)
        {

            //Restaurant=  new Core.Restaurant();
            //Restaurant.Id = restaurantId;
            Restaurant = _restaurantData.GetId(restaurantId);
            //if Restaurant Not Found Redirect to another Page
            if(Restaurant==null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
