using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseRequest
    {
        public int PRID { get; set; }
        public int ManagerID { get; set; }
        public string DateTime { set; get; }
        public int Status { get; set; }
    }
}
