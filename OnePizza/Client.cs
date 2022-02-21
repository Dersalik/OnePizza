using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePizza
{
    public class Client
    {
        public static int ClientNumber;

        public int LikedIngredientNum;
        public List<Ingredient> LikedIngredients = new List<Ingredient>();
        public int DislilkedIngredientNum;
        public List<Ingredient> DislikedIngredients =new List<Ingredient> ();



    }
}
