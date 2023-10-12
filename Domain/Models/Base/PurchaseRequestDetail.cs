using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseRequestDetail
    {
        public int PRDID { get; set; }
        public int Quantity { get; set; }
        public int Unit { set; get; }
        public int Row { set; get; }
        public int NetPrice { set; get; }
        public IList<PurchaseRequest> PRID { get; set; }
        public IList<Food> FoodID { get; set; }
    }
}
