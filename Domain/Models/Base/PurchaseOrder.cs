﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public int CreatorID { get; set; }
        public User? Manager { get; set; }
        public int? PurchaseRequestID { get; set; }
        public PurchaseRequest? PurchaseRequest { get; set; }
        public IList<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; }
    }
}
