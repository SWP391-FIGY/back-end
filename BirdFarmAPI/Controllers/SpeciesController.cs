using Application.ResponseModels;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using Infracstructures.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _speciesService;
        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        #region Create Species
        [HttpPost]
        public async Task<IActionResult> CreateSpecies(Species species)
        {
            try
            {
                if (species.Name.IsNullOrEmpty())
                    return BadRequest(new BaseFailedResponseModel
                    {
                        Status = BadRequest().StatusCode,
                        Message = "Name is null!!!"
                    });
                var result = await _speciesService.CreateSpecies(species);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = "Name dupplicated!!!",
                    Errors = ex,
                });
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

        #region Update Species
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecies(int id, Species species)
        {
            try
            {
                var result = await _speciesService.UpdateSpecies(id, species);
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

        #region Get All Species
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var species = await _speciesService.GetAllSpecies();

                return Ok(species);
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

        #region Get Species By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var result = await _speciesService.GetSpeciesByID(id);
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

        #region Get Species By Name
        [HttpGet("/name/{name}")]
        public async Task<IActionResult> GetSpeciesByName(string name)
        {
            try
            {
                if (name.IsNullOrEmpty())
                {
                    return Ok(await _speciesService.GetAllSpecies());
                }

                var result = await _speciesService.GetSpeciesByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Delete Species
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            try
            {
                var species = await _speciesService.DeleteSpecies(id);
                return Ok(species);
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
