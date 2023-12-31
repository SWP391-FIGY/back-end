﻿using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;

        public CageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region AddNewCage
        public async Task<Cage> AddNewCage(Cage cage)
        {
            await _unitOfWork.CageRepo.Insert(cage);
            
            if (await _unitOfWork.SaveChangeAsync() > 0)
                return cage;
            else throw new Exception("Add Cage failed!!!");
        }
        #endregion

        #region Get Cage By ID
        public async Task<Cage> GetCageByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID less than 0");
            }
            var cage = await _unitOfWork.CageRepo.GetByIDAsync(id);
            return cage;
        }
        #endregion

        #region Get Cage List
        public async Task<IQueryable<Cage>> GetCageList()
        {
            var cage = _unitOfWork.CageRepo.Get();
            if(cage?.Count() == null) 
            {
                throw new InvalidOperationException();
            }
            return cage;
        }
        #endregion

        #region Update Cage
        public async Task<Cage> UpdateCage(int id, Cage cage)
        {
            _unitOfWork.CageRepo.Update(cage);
            var check = await _unitOfWork.SaveChangeAsync();
            if (check == 0) 
            {
                throw new ArgumentException("Update failed!!!");
            }
            return cage;
        }
        #endregion

        #region Delete Cage
        public async Task<Cage> DeleteCage(int id)
        {
            var cage = await _unitOfWork.CageRepo.GetByIDAsync(id);
            _unitOfWork.CageRepo.Delete(cage);
            var check = await _unitOfWork.SaveChangeAsync();

            if(check == 0)
            {
                throw new ArgumentException("Delete failed!!!");
            }
            return null;
        }
        #endregion
    }
}
