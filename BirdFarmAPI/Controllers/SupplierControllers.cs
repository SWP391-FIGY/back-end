using Application.ResponseModels;
using Domain.Models.Base;
using Infracstructures.Interfaces;
using Infracstructures.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.IdentityModel.Tokens;

namespace BirdFarmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierControllers : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierControllers(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        #region Add new Supplier
        [HttpPost]
        public async Task<IActionResult> CreateSupplier(Supplier supplier)
        {
            try
            {
                if (supplier.Name.IsNullOrEmpty())
                {
                    return BadRequest(new BaseFailedResponseModel
                    {
                        Status = BadRequest().StatusCode,
                        Message = "Name is null!!!"
                    });
                }
                var result = await _supplierService.NewSupplier(supplier);
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

        #region Get Supplier By ID
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var result = await _supplierService.GetSupplierByID(id);
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

        #region Get Supplier By Name
        /*[HttpGet("/name/{name}")]
        public async Task<IActionResult> GetSupplierByName(string name)
        {
            try
            {
                if (name.IsNullOrEmpty())
                {
                    return Ok(await _supplierService.GetSupplierList());
                }

                var result = await _supplierService.GetSupplierByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/
        #endregion

        #region Get Supplier List
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _supplierService.GetSupplierList();
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

        #region Update Supplier
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier)
        {
            try
            {
                var result = await _supplierService.UpdateSupplier(id, supplier);
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

        #region Delete Supplier
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                var sup = await _supplierService.DeleteSupplier(id);
                return Ok(sup);
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
