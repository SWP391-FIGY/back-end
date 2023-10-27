using AutoMapper;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class CageService : ICageService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public async Task<Cage> AddNewCage(Cage cage)
        {
            await _unitOfWork.CageRepo.Insert(cage);
            
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return cage;
            else throw new Exception("Add Cage failed!!!");
        }

        public async Task<Cage> GetCageByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID less than 0");
            }
            var cage = await _unitOfWork.CageRepo.GetByIDAsync(id);
            return cage;
        }

        public async Task<IQueryable<Cage>> GetCageList()
        {
            var cage = _unitOfWork.CageRepo.Get();
            if(cage?.Count() == null) 
            {
                throw new InvalidOperationException();
            }
            return cage;
        }
    }
}
