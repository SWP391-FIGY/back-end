
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
    public class BirdService : IBirdService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly ICurrentTime _currentTime;

        public BirdService(ICurrentTime currentTime)
        {
            _currentTime = currentTime;
        }

        #region Add New Bird
        public async Task<Bird> AddNewBird(Bird bird)
        {
            bird.LastModifyDate = _currentTime.GetCurrentTime();
            await _unitOfWork.BirdRepo.Insert(bird);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return bird;
            else throw new Exception("Add Bird failed!!!");
        }
        #endregion

        #region Update Bird
        public async Task<Bird> UpdateBird(Bird bird, int id)
        {
            var birdObj = await _unitOfWork.BirdRepo.GetByIDAsync(id);
            if (birdObj == null) throw new Exception("Bird does not exist!!!");

            bird.LastModifyDate = _currentTime.GetCurrentTime();
            _unitOfWork.BirdRepo.Update(birdObj);
            return birdObj;
        }
        #endregion

        #region Get Bird By ID
        public async Task<Bird> GetBirdByID(int id)
        {            
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var bird = await _unitOfWork.BirdRepo.GetByIDAsync(id);
            return bird;
        }
        #endregion

        #region Get Bird List
        public async Task<IQueryable<Bird>> GetAllBird()
        {
            var birdList = _unitOfWork.BirdRepo.Get();

            if (birdList == null) throw new InvalidOperationException();

            return birdList;
        }
        #endregion
    }
}
