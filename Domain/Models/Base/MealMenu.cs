using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class MealMenu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public int BirdStatus { get; set; }
        public int MenuStatus { get; set; }
        public string NutritionalIngredients { get; set; }
        public IList<Spiece> SpieceID { get; set; }
    }
}
