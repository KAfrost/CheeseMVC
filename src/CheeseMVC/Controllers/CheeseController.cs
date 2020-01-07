using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // list of objects - these should both be handled outside of the controller and stored in the model
        //static private List<Cheese> Cheeses = new List<Cheese>();
        // Dictionary version
        //static private Dictionary<string,string> Cheese = new Dictionary<string,string>();


        // GET: /<controller>/
        public IActionResult Index()
        {
            // If using AddCheeseViewModel - don't forget to add the "using CheeseMVC.ViewModels;" at the top
            // AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            // return View (addCheeseViewModel);

            CheeseListViewModel model = new CheeseListViewModel {
                Cheeses = CheeseData.GetAll()
            };

            // When using a ViewBag - 
            // ViewBag.cheeses = CheeseData.GetAll();
            // If you use ViewData - works the same as above
            // ViewData["cheese"] = CheeseData.GetAll();

            return View(model);

            //To use a list of objects
            // List<Cheese> cheeses = CheeseData.GetAll();
            // return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        // This is how to customize a route
        // [Route("/Cheese/Add")]
        // public IActionResult NewCheese(Cheese newCheese)

        // If creating the object inside the method
        // public IActionResult NewCheese(string name, string description)

        // model binding makes it so we don't have to create the object within the method
        //public IActionResult Add(Cheese newCheese)
        // { 
        //  CheeseData.Add(newCheese);
        //  return Redirect ("/Cheese") 
        // }
        //these can be called the same thing because the above Add method is for a Get method and will return the 
        //View, and this Add method will accept a Post request and add the new instance of a cheese object

        // If using the AddCheeseViewModel
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            // Add validation to the AddCheeseViewModel
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                    Rating = addCheeseViewModel.Rating
                };
                CheeseData.Add(newCheese);

                // this is basically saying this to the system (right side of the assignment isn't actual syntax
                // for this to work you must have a default constructor 
                // Cheese newCheese = new Cheese();
                // newCheese.Name = Request.get("name";
                // newCheese.Description = Request.get("description");


                //Add the new cheese to existing cheeses using a constructor
                // Cheeses.Add(new Cheese(name, description));

                //Add the new cheese to existing cheese using the "default" consructor
                //Cheese newCheese = new Cheese {
                //  Description = description,
                //  Name = name
                //};
                // Cheeses.Add(newCheese);


                // ^ that is the same as this - just "shorthand"
                //Cheese newCheese = new Cheese();
                //newCheese.Description = description;
                //newCheese.Name = name;

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        // receive an array of integers that represents the id's of the cheeses we want to delete
        public IActionResult Remove(int[] cheeseIds)
        {
            //remove cheeses from list using LINQ syntax

            // loop oveer each cheeseId coming in from the array of cheeseIds
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);

                // remove all the cheeses where all items(x) in the Cheeses list where 
                // the cheeseid of the item is equal to the cheeseId that we're currently consdering in the loop
                //becomes obsolete when we create the CheeseData
                //Cheeses.RemoveAll(x => x.CheeseId == cheeseId);
            }

            return Redirect("/");

        }

        public IActionResult Detail(int id)
        {
            ViewBag.cheese = CheeseData.GetById(id);
            ViewBag.title = "Cheese Detail";
            return View();
        }

        public IActionResult Edit(int cheeseId)
        {
            ViewBag.cheese = CheeseData.GetById(cheeseId);
            return View();

        }
        [HttpPost]
        public IActionResult Edit(EditViewModel vm)
        {
            // valdidate form data
            if (ModelState.IsValid)
            {
                Cheese ch = CheeseData.GetById(vm.CheeseId);
                ch.Name = vm.Name;
                ch.Description = vm.Description;
                ch.Type = vm.Type;
            }
            return Redirect ("/Cheese");
        }

    }
}
