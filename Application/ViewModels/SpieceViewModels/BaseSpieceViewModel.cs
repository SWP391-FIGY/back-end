﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SpieceViewModels
{
    public class BaseSpieceViewModel
    {
        public string SpieceName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Voice { get; set; }
        public string ImageLink { get; set; }
        public int Age { get; set; }
        public string Habitat { set; get; }
    }
}
