using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IBirdService
    {
        public Task<Bird> AddNewBird(Bird bird);
        public Task<Bird> GetBirdByID(int id);
        public Task<Bird> UpdateBird(Bird bird, int id);
        public Task<IQueryable<Bird>> GetAllBird();
        public Task<Bird> DeleteBird(int id);
    }
}
