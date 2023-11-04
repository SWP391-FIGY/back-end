using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class MealMenuService : IMealMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MealMenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Add New MealMenu
        public async Task<MealMenu> AddNewMealMenu(MealMenu mealMenu)
        {
            await _unitOfWork.MealMenuRepo.Insert(mealMenu);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return mealMenu;
            else throw new Exception("Add Meal Menu failed!!!");
        }
        #endregion

        #region Get MealMenu By ID
        public async Task<MealMenu> GetMealMenuByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var mealMenu = await _unitOfWork.MealMenuRepo.GetByIDAsync(id);
            return mealMenu;
        }
        #endregion

        #region Get MealMenu List
        public async Task<IQueryable<MealMenu>> GetAllMealMenu()
        {
            var mealMenuList = _unitOfWork.MealMenuRepo.Get();

            if (mealMenuList == null) throw new InvalidOperationException();

            return mealMenuList;
        }
        #endregion

        #region Update MealMenu
        public async Task<MealMenu> UpdateMealMenu(MealMenu mealMenu, int id)
        {

            _unitOfWork.MealMenuRepo.Update(mealMenu);
            await _unitOfWork.SaveChangeAsync();
            return mealMenu;
        }
        #endregion

        #region Delete MealMenu
        public async Task<MealMenu> DeleteMealMenu(int id)
        {
            var mealMenu = await _unitOfWork.MealMenuRepo.GetByIDAsync(id);
            _unitOfWork.MealMenuRepo.Delete(mealMenu);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0)
            {
                throw new ArgumentException("Delete Failed!!!");
            }
            return null;
        }
        #endregion
    }
}
