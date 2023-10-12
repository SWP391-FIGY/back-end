using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PurchaseRequestDetailViewModels
{
    public class PurchaseRequestDetailBaseViewModels
    {
        public int Quantity { get; set; }
        public int Unit { set; get; }
        public int Row { set; get; }
        public int NetPrice { set; get; }
        public IList<PurchaseRequest> PRID { get; set; }
        public IList<Food> FoodID { get; set; }
    }
}
