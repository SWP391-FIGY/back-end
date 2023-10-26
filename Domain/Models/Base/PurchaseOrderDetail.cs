﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseOrderDetail
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int Unit { get; set; }
        public int NetPrice { get; set; }
        public string DeliverDate { get; set; }
        public int POID { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public int FoodID { get; set; }
        public Food? Food { get; set; }
    }
}
