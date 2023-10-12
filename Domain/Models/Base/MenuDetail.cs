using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class MenuDetail
    {
        public int MDID { get; set; }
        public int Quantity { get; set; }
        public IList<MealMenu> MenuID { get; set; }
        public IList<Food> FoodID { get; set; }
    }
}
