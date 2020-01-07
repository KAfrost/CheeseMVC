using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        //List of Cheese objects
        static private List<Cheese> cheeses = new List<Cheese>();

        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        public static Cheese GetById(int cheeseId)
        {
            return cheeses.Single(x => x.CheeseId == cheeseId);
        }

        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        public static bool Remove(int cheeseId)
        {
            return cheeses.Remove(GetById(cheeseId));
        }

  
    }
}
