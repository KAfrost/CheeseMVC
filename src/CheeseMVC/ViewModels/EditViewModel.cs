using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class EditViewModel
    {
        [Required]
        //You can customize the way the ViewModel is displayed in the view thats different from the property name
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }
        // You can also specify what the error message is
        [Required(ErrorMessage = "You must give your cheese a description.")]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        // don't forget to add the using statement for the new class
        // hold the option that is selected
        public CheeseType Type { get; set; }
    }

    public EditCheeseViewModel();
        

