using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Cage
    {
        public int CageID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Area { get; set; }
        public string Type { get; set; }
        public int CageStatus { set; get; }
        public int Capacity { get; set; }
        public IList<Bird> Birds { get; set; }
    }
}
