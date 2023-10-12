using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Task
    {
        public int UniqueID { get; set; }
        public string TaskName { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public IList<Bird> BirdID { get; set; }
        public IList<Cage> CageID { get; set; }
        public IList<User> StaffID { get; set; }

    }
}
