using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IFeedingPlanService
    {
        public Task<FeedingPlan> AddNewFeedingPlan(FeedingPlan feedingPlan);
        public Task<FeedingPlan> GetFeedingPlanByID(int id);
        public Task<FeedingPlan> UpdateTask(FeedingPlan feedingPlan, int id);
        public Task<IQueryable<FeedingPlan>> GetAllFeedingPlan();
    }
}
