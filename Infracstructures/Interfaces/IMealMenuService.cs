using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IMealMenuService
    {
        public Task<MealMenu> AddNewMealMenu(MealMenu mealMenu);
        public Task<MealMenu> GetMealMenuByID(int id);
        public Task<MealMenu> UpdateMealMenu(MealMenu mealMenu, int id);
        public Task<IQueryable<MealMenu>> GetAllMealMenu();
    }
}
