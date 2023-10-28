
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
        private readonly IMapper _mapper;

        public BirdService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Bird> AddNewBird(Bird bird)
        {
            await _unitOfWork.BirdRepo.Insert(bird);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return bird;
            else throw new Exception("Add Bird failed!!!");
        }

        public async Task<Bird> UpdateBird(Bird bird, int id)
        {
            var birdObj = await _unitOfWork.BirdRepo.GetByIDAsync(id);
            if (birdObj == null) throw new Exception("Bird does not exist!!!");

            _unitOfWork.BirdRepo.Update(birdObj);
            return birdObj;
        }

        public async Task<Bird> GetBirdByID(int id)
        {            
            if (id <= 0)
            {
                throw new ArgumentException("Id can not be less than 0 !!!");
            }
            var bird = await _unitOfWork.BirdRepo.GetByIDAsync(id);
            return bird;
        }

    }
}
