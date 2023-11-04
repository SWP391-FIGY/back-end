using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class InventoryLog
    {
        public int ID { get; set; }
        public int? FoodId { get; set; }
        public DateTime CreateDate { get; set; }
        public double Quantity { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public Food? Food { get; set; }


    }
}
