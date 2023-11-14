using Infracstructures.Interfaces;
using Application.ResponseModels;
using Domain.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Application.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Infracstructures.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BirdFarmAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration) 
        {
            _userService = userService;
            _configuration = configuration;
        }

        #region Add New User
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                var userObj = await _userService.AddUser(user);
                return Ok(userObj);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Errors = ex,
                });
            }
        }
        #endregion

        #region Get User By ID
        [Authorize()]
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Invalid parameters",
                    Errors = ex.Message
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Not found",
                    Errors = ex.Message
                });
            }
        }
        #endregion

        #region Get User List
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var user = await _userService.GetUserList();
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Internal server error",
                    Errors = ex.Message
                });
            }
        }
        #endregion

        #region Update User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(int id, User user)
        {
            try
            {
                var result = await _userService.UpdateUser(id, user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Update Failed",
                    Errors = ex.Message
                });
            }
        }
        #endregion

        #region Login with email and password hashed
        [HttpPost("login")]
        public async Task<IActionResult> LoginAndGenerateToken(UserLoginVM userLoginVM)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal;
                var result = await _userService.LoginAndGenerateToken(userLoginVM.Email, userLoginVM.Password);
                var tokenValidated = JWTHelpers.ValidateToken(result.Item1, _configuration, out claimsPrincipal);
                return Ok(new
                {
                    Token = result.Item1,
                    UserInfo = new
                    {
                        result.Item2.Name, 
                        result.Item2.Email,
                        result.Item2.Role,
                        result.Item2.Status,
                        result.Item2.ID,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Login Failed",
                    Errors = ex.Message
                });
            }
        }
        #endregion
        #region Login with Firebase Token
        [HttpPost("firebase")]
        public async Task<IActionResult> LoginAndGenerateToken([FromBody] FirebaseLoginVM firebaseLoginVM)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal;
                var result = await _userService.LoginAndGenerateToken(firebaseLoginVM.FirebaseToken);
                var tokenValidated = JWTHelpers.ValidateToken(result.Item1, _configuration, out claimsPrincipal);
                return Ok(new
                {
                    Token = result.Item1,
                    UserInfo = new
                    {
                        result.Item2.Name,
                        result.Item2.Email,
                        result.Item2.Role,
                        result.Item2.Status,
                        result.Item2.ID,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Login Failed",
                    Errors = ex.Message
                });
            }
        }
        #endregion

        #region Get current user
        [HttpPost("me")]
        public async Task<IActionResult> GetCurrentLoginUser([FromBody] CurrentUserTokenVM currentUser)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal;
                var tokenValidated = JWTHelpers.ValidateToken(currentUser.UserToken, _configuration, out claimsPrincipal);
                if (claimsPrincipal == null) throw new Exception("Invalid claims");
                var claims = new
                {
                    ID = claimsPrincipal.FindFirst("UserId").Value,
                    Email = claimsPrincipal.FindFirst("Email").Value,
                    Name = claimsPrincipal.FindFirst("Name").Value,
                    Role = claimsPrincipal.FindFirst("Role").Value,

                };
                return Ok(claims);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Login Failed",
                    Errors = ex.Message
                });
            }
        }
        #endregion
    }
}
