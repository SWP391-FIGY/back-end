using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseOrder
    {
        public int POID { get; set; }
        public string DateTime { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public IList<User> ManagerID { get; set; }
        public IList<PurchaseRequest> PRID { get; set;}
    }
}
