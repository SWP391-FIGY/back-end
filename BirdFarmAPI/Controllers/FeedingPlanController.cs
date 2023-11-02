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
    public class FeedingPlanController : ControllerBase
    {
        private readonly IFeedingPlanService _feedingPlanService;

        public FeedingPlanController(IFeedingPlanService feedingPlanService)
        {
            _feedingPlanService = feedingPlanService;
        }

        #region Add New Feeding Plan
        [HttpPost]
        public async Task<IActionResult> AddNewFeedingPlan(FeedingPlan feedingPlan)
        {
            try
            {
                var result = await _feedingPlanService.AddNewFeedingPlan(feedingPlan);
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

        #region Update Feeding Plan
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedingPlan(FeedingPlan feedingPlan, int Id)
        {
            try
            {
                var result = await _feedingPlanService.UpdateTask(feedingPlan, Id);
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

        #region Get Feeding Plan By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var result = await _feedingPlanService.GetFeedingPlanByID(id);
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

        #region Get All Feeding Plan
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _feedingPlanService.GetAllFeedingPlan();
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
    }
}
