using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FeedingPlanViewModels
{
    public class FeedingPlanBaseViewModels
    {
        public string DateTime { set; get; }
        public string FeedingStatus { set; get; }
        public string Notation { set; get; }
        public IList<Bird> BirdID { get; set; }
        public IList<MealMenu> MenuID { get; set; }
    }
}
