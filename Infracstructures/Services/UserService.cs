using Domain.Models.Base;
using Infracstructures.Helpers;
using Infracstructures.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _currentTime = currentTime;
        }
        public async Task<User> AddUser(User user)
        {
            user.Password = user.Password.Hash();
            await _unitOfWork.UserRepo.Insert(user);

            if (await _unitOfWork.SaveChangeAsync() > 0)
                return user;
            else throw new Exception("Add user failed!!!");
        }

        public async Task<User> GetUserById(int id)
        {
            if (id < 0) throw new Exception("ID can not be less than 0!!!");

            var user = await _unitOfWork.UserRepo.GetByIDAsync(id);
            user.Password = "";
            return user;
        }

        public async Task<IQueryable<User>> GetUserList()
        {
            var users = _unitOfWork.UserRepo.Get();
            if (users?.Count() == null)
            {
                throw new InvalidOperationException();
            }
            foreach (var user in users)
            {
                user.Password = "";
            }
            return users;
        }

        public async Task<Tuple<string, User>> LoginAndGenerateToken(string email, string password)
        {
            var existedUser = await _unitOfWork.UserRepo.Get().FirstOrDefaultAsync(u => u.Email == email && u.Password == password.Hash());

            if (existedUser != null)
            {
                return new Tuple<string, User>(JWTHelpers.GenerateJWT(existedUser, _currentTime.GetCurrentTime(), _configuration), existedUser);
            }
            throw new Exception("Wrong Credential");
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existedEntity = await _unitOfWork.UserRepo.GetByIDAsync(id);
            _unitOfWork.UserRepo.Update(existedEntity);
            var check = await _unitOfWork.SaveChangeAsync();

            if (check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }
            return user;
        }
    }
}
