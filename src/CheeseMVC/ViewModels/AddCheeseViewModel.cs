using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        //You can customize the way the ViewModel is displayed in the view thats different from the property name
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }
        // You can also specify what the error message is
        [Required(ErrorMessage = "You must give your cheese a description.")]
        public string Description { get; set; }
        
        [Range (1, 5)]
        public int Rating { get; set; }

        // don't forget to add the using statement for the new class
        // hold the option that is selected
        public CheeseType Type { get; set; }

        //present user with the options
        public List<SelectListItem> CheeseTypes { get; set; }

        public AddCheeseViewModel()
        {
            // initialize the select list - each item in the enum uses an int value
            // 0 - Hard, 1 - Soft, 2 - Fake
            CheeseTypes = new List<SelectListItem>();

            // create the items for the list
            // the HTML associated with this list item...
            //<option value="0">Hard</option>
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });

            // can iterate across the enum to create these... do it later if you feel like it. 
        }

    }
}
