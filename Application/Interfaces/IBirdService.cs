using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBirdService
    {
        public Task<string> AddNewBird(Bird bird);
        public Task<string> GetBirdByID(int id);
        
    }
}
