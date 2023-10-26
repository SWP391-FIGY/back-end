using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class MealMenu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public int BirdStatus { get; set; }
        public int MenuStatus { get; set; }
        public string NutritionalIngredients { get; set; }
        public int SpeceID { get; set; }
        public Species? Species { get; set; }
        public IList<MenuDetail>? MenuDetails { get; set; }
        public IList<FeedingPlan>? FeedingPlans { get; set; }  
    }
}
