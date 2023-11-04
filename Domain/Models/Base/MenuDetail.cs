using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class MenuDetail
    {
        public int ID { get; set; }
        public int MealMenuID { get; set; }
        public int FoodID { get; set; }
        public double Quantity { get; set; }
        public MealMenu? MealMenu { get; set; }
        public Food? Food { get; set; }
    }
}
