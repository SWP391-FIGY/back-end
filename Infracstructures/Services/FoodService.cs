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
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        #region Add New Food
        public async Task<Food> AddNewFood(Food food)
        {
            await _unitOfWork.FoodRepo.Insert(food);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return food;
            else throw new Exception("Add food failed!!!");
        }
        #endregion

        #region Get Food By ID
        public async Task<Food> GetFoodById(int id)
        {
            if (id < 0) throw new Exception("ID can not be less than 0!!!");

            var food = await _unitOfWork.FoodRepo.GetByIDAsync(id);
            return food;
        }
        #endregion

        #region Get Food By Name
        public async Task<IQueryable<Food>> GetFoodByName(string name)
        {
            var food = _unitOfWork.FoodRepo.Get();
            var foodName = food.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return foodName;
        }
        #endregion

        #region Get Food List
        public async Task<IQueryable<Food>> GetFoodList()
        {
            var food = _unitOfWork.FoodRepo.Get();
            if(food?.Count() == null)
            {
                throw new InvalidOperationException();
            }
            return food;
        }
        #endregion

        #region Update Food
        public async Task<Food> UpdateFood(int id, Food food)
        {
            var foodObj = await _unitOfWork.FoodRepo.GetByIDAsync(id);
            _unitOfWork.FoodRepo.Update(foodObj);
            var check = await _unitOfWork.SaveChangeAsync();

            if(check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }
            return foodObj;
        }
        #endregion

        #region Delete Food
        public async Task<Food> DeleteFood(int id)
        {
            var foodObj = await _unitOfWork.FoodRepo.GetByIDAsync(id);
            _unitOfWork.FoodRepo.Delete(foodObj);

            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0)
            {
                throw new ArgumentException("Food was not deleted!!!");
            }
            return null;
        }
        #endregion
    }
}
