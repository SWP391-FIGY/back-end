using Domain.Models.Base;
using FirebaseAdmin.Auth;
using Google.Apis.Auth;
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

            var userList = _unitOfWork.UserRepo.Get();

            // Check duplicate email
            if (userList.Any(x => x.Email.ToLower().Equals(user.Email.ToLower()))) 
                throw new Exception("Duplicate email!!!");
            foreach (User checkUser in userList)
            {
                if (!string.IsNullOrEmpty(checkUser.FirebaseID) && !string.IsNullOrEmpty(user.FirebaseID))
                {
                    if (checkUser.FirebaseID.Equals(user.FirebaseID.ToLower()))
                    {
                        throw new Exception("Duplicate FirebaseID!!!");
                    }
                }
            }

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

        public async Task<Tuple<string, User>> LoginAndGenerateToken(string firebaseToken)
        {


            if (!string.IsNullOrEmpty(firebaseToken))
            {
                try
                {
                    var payload = await VerifyFirebaseTokenAsync(firebaseToken);
                    if (payload != null)
                    {
                        var existedUser = await GetUserByEmail(email: payload.Claims["email"].ToString());
                        if (existedUser.FirebaseID != payload.Uid)
                        {
                            existedUser.FirebaseID = payload.Uid;
                            await _unitOfWork.SaveChangeAsync();
                        }
                        if (existedUser == null)
                        {
                            existedUser = await RegisterFirebaseUser(payload);
                        }

                        existedUser.Password = "";
                        return new Tuple<string, User>(
                            JWTHelpers.GenerateJWT(existedUser, _currentTime.GetCurrentTime(), _configuration),
                            existedUser);
                    }
                }
                catch
                {
                    throw new InvalidJwtException("Invalid token");
                }
            }
            throw new Exception("Wrong Credential");
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            user.Password = user.Password.Hash();
            _unitOfWork.UserRepo.Update(user);
            var check = await _unitOfWork.SaveChangeAsync();

            if (check == 0)
            {
                throw new ArgumentException("Update failed!!!");
            }
            return user;
        }

        public async Task<FirebaseToken> VerifyFirebaseTokenAsync(string idToken)
        {
            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
            return decodedToken;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _unitOfWork.UserRepo.Get().FirstOrDefaultAsync(x => x.Email.Equals(email));
            return user;
        }

        public async Task<User> RegisterFirebaseUser(FirebaseToken payload)
        {
            var email = payload.Claims["email"].ToString();
            var user = new User
            {
                Name = payload.Claims["name"].ToString(),
                Email = email,
                FirebaseID = payload.Uid,
                Role = 1,
                Status = 1,
            };

            await _unitOfWork.UserRepo.Insert(user);
            await _unitOfWork.SaveChangeAsync();
            return user;
        }
    }
}
