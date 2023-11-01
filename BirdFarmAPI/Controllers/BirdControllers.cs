using Application.ResponseModels;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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

        #region Get All Bird
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetBirdList()
        {
            try
            {
                var result = await _birdService.GetAllBird();
                return Ok(result);
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

        #region Delete Bird
        [HttpDelete]
        public async Task<IActionResult> DeleteBird(int id)
        {
            try
            {
                var bird = await _birdService.DeleteBird(id);
                return Ok(bird);
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
    }
}
