using Application.ResponseModels;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BirdControllers : ControllerBase
    {
        private readonly IBirdService _birdService;

        public BirdControllers(IBirdService birdService)
        {
            _birdService = birdService;
        }

        #region Add New Bird
        [HttpPost]
        public async Task<IActionResult> AddNewBird(Bird bird)
        {
            try
            {
                var result = await _birdService.AddNewBird(bird);
                return Ok(result);
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

        #region Update Bird
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBird(Bird bird, int Id)
        {
            try
            {
                var result = await _birdService.UpdateBird(bird, Id);
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

        #region Get Bird By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBirdByID(int id)
        {
            try
            {
                var result = await _birdService.GetBirdByID(id);
                return Ok(result);
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
    }
}
