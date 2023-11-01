using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class FeedingPlanService : IFeedingPlanService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        #region Add New FeedingPlan
        public async Task<FeedingPlan> AddNewFeedingPlan(FeedingPlan feedingPlan)
        {
            await _unitOfWork.FeedingPlanRepo.Insert(feedingPlan);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return feedingPlan;
            else throw new Exception("Add FeedingPlan failed!!!");
        }
        #endregion

        #region Get FeedingPlan By ID
        public async Task<FeedingPlan> GetFeedingPlanByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var feedingPlan = await _unitOfWork.FeedingPlanRepo.GetByIDAsync(id);
            return feedingPlan;
        }
        #endregion

        #region Get Task FeedingPlan
        public async Task<IQueryable<FeedingPlan>> GetAllFeedingPlan()
        {
            var feedingPlanList = _unitOfWork.FeedingPlanRepo.Get();

            if (feedingPlanList == null) throw new InvalidOperationException();

            return feedingPlanList;
        }
        #endregion

        #region Update FeedingPlan
        public async Task<FeedingPlan> UpdateTask(FeedingPlan feedingPlan, int id)
        {
            var feedingPlanObj = await _unitOfWork.FeedingPlanRepo.GetByIDAsync(id);
            if (feedingPlanObj == null) throw new Exception("Feeding Plan does not exist!!!");

            _unitOfWork.FeedingPlanRepo.Update(feedingPlanObj);
            return feedingPlanObj;
        }
        #endregion
    }
}
