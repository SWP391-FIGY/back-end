using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface ISpeciesService
    {
        Task<Species> CreateSpecies(Species species);
        Task<Species> UpdateSpecies(int id, Species species);
        Task<IQueryable<Species>> GetAllSpecies();
        Task<Species> GetSpeciesByID(int id);
        Task<IQueryable<Species>> GetSpeciesByName(string name);
        public Task<Species> DeleteSpecies(int id);
    }
}
