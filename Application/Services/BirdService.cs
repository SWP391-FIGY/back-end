using Application.Interfaces;
using AutoMapper;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BirdService : IBirdService
    {

        public BirdService()
        {
        }

        public Task<string> AddNewBird(Bird bird)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBirdByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
