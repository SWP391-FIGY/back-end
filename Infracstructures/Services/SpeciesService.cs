using Application.Interfaces;
using Domain.Models.Base;
using AutoMapper;
using Infracstructures.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public SpeciesService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Create Species
        public async Task<Species> CreateSpecies(Species species)
        {
            var checkname = _unitOfWork.SpeciesRepo.Get();
            if (checkname?.FirstOrDefault(x => x.Name.Equals(species.Name,
                StringComparison.OrdinalIgnoreCase)) != null)
                throw new ArgumentException();

            await _unitOfWork.SpeciesRepo.Insert(species);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return species;
            else throw new Exception("Create species failed!!!");
        }
        #endregion

        #region Get All Species
        public async Task<IQueryable<Species>> GetAllSpecies()
        {
            var speciesList = _unitOfWork.SpeciesRepo.Get();

            if (speciesList?.ToList().Count == 0)
            {
                throw new InvalidOperationException();
            }
            return speciesList;
        }
        #endregion

        #region Update Species
        public async Task<Species> UpdateSpecies(int id, Species species)
        {
            var exObj = await _unitOfWork.SpeciesRepo.GetByIDAsync(id);
            _unitOfWork.SpeciesRepo.Update(species);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }
            return species;

        }
        #endregion

        #region Get Species By ID
        public async Task<Species> GetSpeciesByID(int id)
        {
            if (id <= 0)
            {
                string msg = "ID cant be less than 0";
                throw new ArgumentException(msg);
            }
            var species = await _unitOfWork.SpeciesRepo.GetByIDAsync(id);
            return species;
        }
        #endregion

        #region Get Species By Name
        public async Task<IQueryable<Species>> GetSpeciesByName(string name)
        {
            var exList = _unitOfWork.SpeciesRepo.Get();
            var exListName = exList.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            return exListName;
        }
        #endregion
    }
}
