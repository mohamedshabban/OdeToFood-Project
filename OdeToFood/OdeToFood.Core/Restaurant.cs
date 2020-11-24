using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
    //IValidation To Custom Code or Your Model Or Entity
    public class Restaurant//:IValidatableObject
    {
        public int Id { get; set; }
        //To avoid Empty Name In Form
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]//[Required ,StringLength(80)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
       
    }
}
