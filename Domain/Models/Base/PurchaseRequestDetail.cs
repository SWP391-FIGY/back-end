using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseRequestDetail
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Unit { set; get; }
        public int Row { set; get; }
        public int NetPrice { set; get; }
        public int PurchaseRequestID { get; set; }
        public int FoodID { get; set; }
        public PurchaseRequest? PurchaseRequest { get; set; }
        public Food? Food { set; get; }
    }
}
