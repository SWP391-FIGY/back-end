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
        Task<Species> CreateSpeciesAsync(Species species);
        Task<Species> UpdateSpeciesAsync(int id, Species species);
        Task<IQueryable<Species>> GetAllSpeciesAsync();
        Task<Species> GetSpeciesByIDAsync(int id);
        Task<IQueryable<Species>> GetSpeciesByNameAsync(string name);
    }
}
