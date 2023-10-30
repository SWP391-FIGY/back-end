using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface ICageService
    {
        public Task<Cage> AddNewCage(Cage cage);
        public Task<Cage> GetCageByID(int id);
        public Task<IQueryable<Cage>> GetCageList();
        public Task<Cage> UpdateCage(int id, Cage cage);
    }
}
