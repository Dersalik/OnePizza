using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePizza
{
    public  class Ingredient
    {
       public string ingredientName { get; set; }
       public int numOfLikesByCustomer;
       public int numOfDislikesbycustomer;


        public Ingredient(string Name)
        {
            this.ingredientName = Name;
        }
    }
}
