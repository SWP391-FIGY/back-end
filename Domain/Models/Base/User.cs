using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
        public IList<Task>? Tasks { get; set; }
        public IList<PurchaseOrder>? PurchaseOrders { get; set; }
        public IList<PurchaseRequest>? PurchaseRequests { get; set; }
    }
}
