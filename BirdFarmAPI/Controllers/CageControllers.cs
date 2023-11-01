using Infracstructures.Interfaces;
using Domain.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ResponseModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OData.Query;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CageControllers : ControllerBase
    {
        private readonly ICageService _cageService;
        private readonly ICurrentTime _currenttime;

        public CageControllers(ICageService cageService, ICurrentTime currenttime)
        {
            _cageService = cageService;
            _currenttime = currenttime;
        }

        #region AddNewCage
        [HttpPost]
        public async Task<IActionResult> AddNewCage(Cage cage)
        {
            try
            {
                var cageObj = await _cageService.AddNewCage(cage);
                return Ok(cageObj);
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

        #region Get Cage By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetCageByID(int id)
        {
            try
            {
                var cage = await _cageService.GetCageByID(id);
                return Ok(cage);
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

        #region Get Cage List
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetCageList()
        {
            try
            {
                var cage = await _cageService.GetCageList();
                return Ok(cage);
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

        #region Update Cage
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCage(int id, Cage cage)
        {
            try
            {
                var result = await _cageService.UpdateCage(id, cage);
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

        #region Delete Cage
        [HttpDelete]
        public async Task<IActionResult> DeleteFood(int id)
        {
            try
            {
                var result = await _cageService.DeleteCage(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel()
                {
                    Status = BadRequest().StatusCode,
                    Message = "Delete Failed",
                    Errors = ex.Message
                });
            }
        }
        #endregion
    }
}
