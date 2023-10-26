using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Bird
    {
        public int ID { get; set; }
        public string DoB { set; get; }
        public string Gender { set; get; }
        public string Notation { set; get;}
        public int BirdStatus { get; set; }
        public string LastModifyDate { set; get; }
        public int SpieceID { get; set; }
        public Species? Species { get; set; }
        public int CageID { get; set; }
        public Cage? Cage { get; set; }
        public IList<Task>? Tasks { get; set; }
        public IList<FeedingPlan>? FeedingPlans { get; set; }
        public IList<Log>? logs { get; set; }
    }
}
