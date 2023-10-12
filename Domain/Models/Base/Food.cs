using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string NutritionalIngredients { get; set; }
        public int StorageCondition { set; get; }
    }
}
