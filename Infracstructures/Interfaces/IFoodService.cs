using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IFoodService
    {
        Task<Food> AddNewFood(Food food);
        Task<IQueryable<Food>> GetFoodList();
        Task<Food> GetFoodById(int id);
        Task<IQueryable<Food>> GetFoodByName(string name);
        Task<Food> UpdateFood(int id, Food food);
        Task<Food> DeleteFood(int id);
    }
}
