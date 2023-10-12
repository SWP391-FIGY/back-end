using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Bird
    {
        public int BirdID { get; set; }
        public string DoB { set; get; }
        public string Gender { set; get; }
        public string Notation { set; get;}
        public int BirdStatus { get; set; }
        public string LastModifyDate { set; get; }
        public IList<Spiece> SpieceID { get; set; }
        public IList<Cage> CageID { get; set; }
    }
}
