using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Spiece
    {
        public int SpieceID { get; set; }
        public string SpieceName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Voice { get; set; }
        public string ImageLink { get; set; }
        public int Age { get; set; }
        public string Habitat { set; get; }
        public int Total { get; set; }
    }
}
