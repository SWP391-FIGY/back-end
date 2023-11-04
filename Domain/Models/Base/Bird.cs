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
        public int SpeciesId { get; set; }
        public int CageID { get; set; }
        public string? DoB { set; get; }
        public string Gender { set; get; }
        public string? Description { set; get;}
        public int BirdStatus { get; set; }
        public string BirdImageUrl { set; get; }
        public DateTime? LastModifyDate { set; get; }
        public Species? Species { get; set; }
        public Cage? Cage { get; set; }
        public IList<Tasks>? Tasks { get; set; }
        public IList<FeedingPlan>? FeedingPlans { get; set; }
        public IList<Log>? Logs { get; set; }
    }
}
