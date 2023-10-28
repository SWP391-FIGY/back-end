using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class FeedingPlan
    {
        public int ID { get; set; }
        public string DateTime { set; get; }
        public string FeedingStatus { set; get; }
        public string Notation { set; get; }
        public int BirdID { get; set; }
        public int MenuID { get; set; }
        public Bird? Bird { get; set; }
        public MealMenu? MealMenu { get; set; }

    }
}
