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
        public int MealMenuID { get; set; }
        public int BirdID { get; set; }
        public DateTime DateTime { set; get; }
        public string FeedingStatus { set; get; }
        public string Description { set; get; }

        public Bird? Bird { get; set; }
        public MealMenu? MealMenu { get; set; }

    }
}
