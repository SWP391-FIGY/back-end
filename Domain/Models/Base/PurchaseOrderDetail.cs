using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseOrderDetail
    {
        public int PODID { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public int NetPrice { get; set; }
        public string DeliverDate { get; set; }
        public IList<PurchaseOrder> POID { get; set; }
        public IList<Food> FoodID { get; set; }
    }
}
