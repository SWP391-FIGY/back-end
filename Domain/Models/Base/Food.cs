using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NutritionalIngredients { get; set; }
        public string? StorageCondition { set; get; }
        public string Unit { set; get; }
        public double StandardPrice { set; get; }
        public int SafetyThreshold { set; get; }
        public IList<PurchaseRequestDetail>? PurchaseRequestDetails { get; set;}
        public IList<MenuDetail>? MenuDetails { get; set; }
    }
}
