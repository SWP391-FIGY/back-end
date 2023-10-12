using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MealMenuViewModels
{
    public class MealMenuBaseViewModels
    {
        public string MenuName { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public int BirdStatus { get; set; }
        public int MenuStatus { get; set; }
        public string NutritionalIngredients { get; set; }
        public IList<Spiece> SpieceID { get; set; }
    }
}
