using Infracstructures.Interfaces;
using Domain.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ResponseModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CageControllers : ControllerBase
    {
        private readonly ICageService _cageService;

        public CageControllers(ICageService cageService)
        {
            _cageService = cageService;
        }

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

        [HttpGet("{id}")]
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
        [HttpGet]
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

    }
}
