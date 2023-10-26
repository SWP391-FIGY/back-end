﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IBirdRepository
    {
        public Task<string> GetBirdByID(int id);
    }
}
