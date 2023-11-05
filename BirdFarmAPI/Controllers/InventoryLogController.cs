using Application.ResponseModels;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using Infracstructures.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryLogController : ControllerBase
    {
        private readonly IInventoryLogService _inventoryLogService;

        public InventoryLogController(IInventoryLogService inventoryLogService)
        {
            _inventoryLogService = inventoryLogService;
        }

        #region Add New InventoryLog
        [HttpPost]
        public async Task<IActionResult> AddNewInventoryLog(InventoryLog inventoryLog)
        {
            try
            {
                var result = await _inventoryLogService.AddNewInventoryLog(inventoryLog);
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

        #region Update InventoryLog
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryLog(InventoryLog inventoryLog, int id)
        {
            try
            {
                var result = await _inventoryLogService.UpdateInventoryLog(inventoryLog, id);
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

        #region Get InventoryLog By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var result = await _inventoryLogService.GetInventoryLogByID(id);
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

        #region Get All InventoryLog
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _inventoryLogService.GetAllInventoryLog();
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

        #region Delete InventoryLog
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryLog(int id)
        {
            try
            {
                var log = await _inventoryLogService.DeleteInventoryLog(id);
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
