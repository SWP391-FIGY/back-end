using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class FoodService : IFoodService
    {
        public Task<Food> AddNewFood(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
