using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        //To Retrieve Items of List and HTML Select
        public IEnumerable<SelectListItem> Cusines { get; set; }
        //When click on save button 
        //this restaurant should populated with information from the form
        [BindProperty]
        public Core.Restaurant Restaurant { get; set; }
        //
        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        //Nullable restaurantId
        public IActionResult OnGet(int? restaurantId)
        {
            //instead of editing in view 
            Cusines = _htmlHelper.GetEnumSelectList<Core.CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetId(restaurantId.Value);
            }
            else
            {
                Restaurant=new Core.Restaurant();
            }
            if (Restaurant == null)
            { return RedirectToPage("./NotFound"); }
            return Page();
        }

        public IActionResult OnPost()
        {
            //if Location with empty string will be handled
            //ModelState["Location"].Errors;
            Cusines = _htmlHelper.GetEnumSelectList<Core.CuisineType>();
            if (!ModelState.IsValid)
            {
                //if all info that passed in via model binding are not valid ?
                //update data 
                return Page();
               
            }
            if(Restaurant.Id>0)
            {_restaurantData.Update(Restaurant);}
            else
            {
                _restaurantData.AddOrCreate(Restaurant);
            }
            _restaurantData.Commit();
            //Dictionary
            TempData["Message"] = "Restaurant Saved Successfully!";
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
                 
        }
    }
}
