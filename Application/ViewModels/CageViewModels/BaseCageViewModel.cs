using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.CageViewModels
{
    public class BaseCageViewModel
    {
        public int CageID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Area { get; set; }
        public string Type { get; set; }
        public string CageStatus { get; set; }
        public string Capacity { get; set; }
    }
}
