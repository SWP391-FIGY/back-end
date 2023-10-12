using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.BirdViewModels
{
    public class BaseBirdViewModel
    {
        public string DoB { get; set; }
        public string Gender { get; set; }
        public string Notation { get; set; }
        public string BirdStatus { get; set; }
        public string LastModifyDate { get; set; }
        public IList<int> SpieceID { get; set; }
        public IList<int> CageID { get; set; }
    }
}
