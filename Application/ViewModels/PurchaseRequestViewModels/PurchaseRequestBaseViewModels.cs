using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PurchaseRequestViewModels
{
    public class PurchaseRequestBaseViewModels
    {
        public int ManagerID { get; set; }
        public string DateTime { set; get; }
        public int Status { get; set; }
    }
}
