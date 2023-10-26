
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class BirdService : IBirdService
    {
        public Task<string> GetBirdByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
