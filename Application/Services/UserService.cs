using Application.Interfaces;
using Application.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        #region LoginAsync
        public async Task<string> LoginAsync(UserLoginViewModel userLogin)
        {
            return null;
        }
        #endregion
    }
}
