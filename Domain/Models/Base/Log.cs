﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Base
{
    public class Log
    {
        public int ID { get; set; }
        public int? BirdID { get; set; }
        public int CageID { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public Cage? Cage { get; set; }
        public Bird? Bird { get; set; }
    }
}
