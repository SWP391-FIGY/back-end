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
    public class MealMenuController : ControllerBase
    {
        private readonly IMealMenuService _mealMenuService;

        public MealMenuController(IMealMenuService mealMenuService)
        {
            _mealMenuService = mealMenuService;
        }
        

        #region Add New MealMenu
        [HttpPost]
        public async Task<IActionResult> AddNewMealMenu(MealMenu mealMenu)
        {
            try
            {
                var result = await _mealMenuService.AddNewMealMenu(mealMenu);
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

        #region Update MealMenu
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMealMenu(MealMenu mealMenu, int Id)
        {
            try
            {
                var result = await _mealMenuService.UpdateMealMenu(mealMenu, Id);
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

        #region Get MealMenu By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var result = await _mealMenuService.GetMealMenuByID(id);
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

        #region Get All MealMenu
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mealMenuService.GetAllMealMenu();
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

        #region Delete MealMenu
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealMenu(int id)
        {
            try
            {
                var mealMenu = await _mealMenuService.DeleteMealMenu(id);
                return Ok(mealMenu);
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
