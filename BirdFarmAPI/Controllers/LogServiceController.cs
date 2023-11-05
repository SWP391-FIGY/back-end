using Application.ResponseModels;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogServiceController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogServiceController(ILogService logService)
        {
            _logService = logService;
        }

        #region Add New Log
        [HttpPost]
        public async Task<IActionResult> AddNewLog(Log log)
        {
            try
            {
                var result = await _logService.AddNewLog(log);
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

        #region Update Log
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLog(Log log, int id)
        {
            try
            {
                var result = await _logService.UpdateLog(log, id);
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

        #region Get Log By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var result = await _logService.GetLogByID(id);
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

        #region Get All Log
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _logService.GetAllLog();
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

        #region Delete Log
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(int id)
        {
            try
            {
                var log = await _logService.DeleteLog(id);
                return Ok(log);
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
