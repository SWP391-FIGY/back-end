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
    public class FoodControllers : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodControllers(IFoodService foodService)
        {
            _foodService = foodService;
        }

        #region Add New Food
        [HttpPost]
        public async Task<IActionResult> AddNewFood(Food food)
        {
            try
            {
                var foodObj = await _foodService.AddNewFood(food);
                return Ok(foodObj);
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

        #region Get Food By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodByID(int id)
        {
            try
            {
                var food = await _foodService.GetFoodById(id);
                return Ok(food);
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

        #region Get Food List
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetFoodList()
        {
            try
            {
                var food = await _foodService.GetFoodList();
                return Ok(food);
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

        #region Get Food By Name
        [HttpGet("{name?}")]
        [EnableQuery]
        public async Task<IActionResult> GetFoodByName(string name)
        {
            try
            {
                if (name == null)
                {
                    return await GetFoodList();
                }
                var result = await _foodService.GetFoodByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Food
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(int id, Food food)
        {
            try
            {
                var result = await _foodService.UpdateFood(id, food);
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
    }
}
