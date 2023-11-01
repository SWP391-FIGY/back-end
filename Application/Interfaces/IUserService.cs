

using Domain.Models.Base;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<IQueryable<User>> GetUserList();
        Task<string> LoginAndGenerateToken(string email, string password);
        Task<User> UpdateUser(int id, User user);

    }
}
