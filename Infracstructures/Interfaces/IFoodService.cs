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
        public Task<Food> AddNewFood(Food food);
        public Task<IQueryable<Food>> GetFoodList();
        public Task<Food> GetFoodById(int id);
        public Task<IQueryable<Food>> GetFoodByName(string name);
        public Task<Food> UpdateFood(int id, Food food);
    }
}
