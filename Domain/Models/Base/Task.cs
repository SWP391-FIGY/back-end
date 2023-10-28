using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Task
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int BirdID { get; set; }
        public int CageID { get; set; }
        public int StaffID { get; set; }
        public Bird? Bird { get; set; }
        public Cage? Cage { get; set; }
        public User Staff { get; set; }

    }
}
