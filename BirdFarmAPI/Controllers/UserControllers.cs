using Application.Interfaces;
using Application.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace BirdFarmAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _userService;
        public UserControllers(IUserService userService) 
        {
            _userService = userService;
        }

        
    }
}
