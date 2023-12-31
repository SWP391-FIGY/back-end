﻿using Domain.Models.Base;
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
        private readonly IUnitOfWork _unitOfWork;

        public FeedingPlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
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

            _unitOfWork.FeedingPlanRepo.Update(feedingPlan);
            await _unitOfWork.SaveChangeAsync();
            return feedingPlan;
        }
        #endregion

        #region Delete FeedingPlan
        public async Task<FeedingPlan> DeleteFeedingPlan(int id)
        {
            var feedingPlan = await _unitOfWork.FeedingPlanRepo.GetByIDAsync(id);
            _unitOfWork.BirdRepo.Delete(feedingPlan);
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
