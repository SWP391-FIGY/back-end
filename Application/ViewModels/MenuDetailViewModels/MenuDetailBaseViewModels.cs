using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MenuDetailViewModels
{
    public class MenuDetailBaseViewModels
    {
        public int Quantity { get; set; }
        public IList<MealMenu> MenuID { get; set; }
        public IList<Food> FoodID { get; set; }
    }
}
