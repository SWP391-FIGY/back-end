using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class FeedingPlan
    {
        public int PlanID { get; set; }
        public string DateTime { set; get; }
        public string FeedingStatus { set; get; }
        public string Notation { set; get; }
        public IList<Bird> BirdID { get; set; }
        public IList<MealMenu> MenuID { get; set; }

    }
}
