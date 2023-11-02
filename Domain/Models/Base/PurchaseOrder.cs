using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public int CreatorID { get; set; }
        public int? PurchaseRequestID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public Supplier? Supplier { get; set; }
        public User? Creator { get; set; }
        public PurchaseRequest? PurchaseRequest { get; set; }
        public IList<PurchaseOrderDetail>? PurchaseOrderDetails { get; set; }
    }
}
