
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<IQueryable<User>> GetUserList();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User user);
        Task<Tuple<string, User>> LoginAndGenerateToken(string email, string rawPassword);
        Task<Tuple<string, User>> LoginAndGenerateToken(string firebaseToken);
    }
}
