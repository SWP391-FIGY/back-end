using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseRequest
    {
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public DateTime DateTime { set; get; }
        public int Status { get; set; }
        public User? Manager { get; set; } 
        public IList<PurchaseOrder>? PurchaseOrders { get; set; }
        public IList<PurchaseRequestDetail>? PurchaseRequestDetails { get; set; }
    }
}
