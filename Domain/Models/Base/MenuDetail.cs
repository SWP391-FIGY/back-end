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
        public int Quantity { get; set; }
        public int MenuID { get; set; }
        public MealMenu? MealMenu { get; set; }
        public IList<Food>? FoodID { get; set; }
    }
}
