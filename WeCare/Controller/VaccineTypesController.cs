using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using DataAccsess_Layer.ViewModel.GeneralResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;
using System;

namespace WeCare.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        #region  CRUD OPEARIONS

        #region GetVaccineTypesById
        /// <summary>
        /// Retrieves a specific VaccineTypes by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpGet("id")]
        public ActionResult<GeneralResponse<VaccineTypes>> GetVaccineTypesById(int id)
        {
            try
            {
                GeneralResponse<VaccineTypes> response = new GeneralResponse<VaccineTypes>();
                VaccineTypes VaccineTypes = _unitOfWork.VaccineTypes.GetById(id);

                if (VaccineTypes != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(VaccineTypes);
                    response.Success = true;


                    return response;
                }
                else
                {
                    response.Message = "Failed To Retrive Data";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region GetAllVaccineTypes
        /// <summary>
        /// Retrieves All VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllVaccineTypes()
        {
            try
            {
                GeneralResponse<VaccineTypes> response = new GeneralResponse<VaccineTypes>();
                var VaccineTypeslst = _unitOfWork.VaccineTypes.GetAll();

                if (VaccineTypeslst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data = _unitOfWork.VaccineTypes.GetAll();
                    response.Success = true;


                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Retrive Data";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }

            catch (Exception ex)
            {
                return BadRequest("NO VaccineTypes HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteVaccineTypesById
        /// <summary>
        /// Delete specific VaccineTypes by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>


        [HttpDelete]
        public IActionResult DeleteVaccineTypes(int id)
        {
            try
            {
                GeneralResponse<VaccineTypes> response = new GeneralResponse<VaccineTypes>();
                VaccineTypes VaccineTypes = _unitOfWork.VaccineTypes.GetById(id);

                if (VaccineTypes != null)
                {
                    _unitOfWork.VaccineTypes.Delete(id);
                    return Ok("The VaccineTypes has Been Deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no VaccineTypes with this id:" + id);
            }


        }
        #endregion




        #region AddVaccineTypes

        /// <summary>
        /// Add New VaccineTypes
        /// parameter (New Instance from VaccineTypes )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpPost]
        public IActionResult AddVaccineTypes([FromQuery] VaccineTypesCreateViewModel VaccineTypes)
        {

            try
            {
                GeneralResponse<VaccineTypes> response = new GeneralResponse<VaccineTypes>();
                if (VaccineTypes != null)
                {
                    VaccineTypes model = new VaccineTypes()
                    {

                        VaccineTypeTittle = VaccineTypes.VaccineTypeTittle,

                        CreationDate = VaccineTypes.CreationDate
                    };
                    _unitOfWork.VaccineTypes.Add(model);
                    response.Message = "The VaccineTypes Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(model);
                    response.Success = true;

                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add VaccineTypes";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the VaccineTypes correctly  ");
            }
        }
        #endregion


        #region UpdateVaccineTypes
        /// <summary>
        /// Update Existing VaccineTypes
        ///   parameter (  Instance from VaccineTypes )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpPut]

        public IActionResult UpdateVaccineTypes([FromQuery] VaccineTypes VaccineTypes)
        {
            try
            {
                GeneralResponse<VaccineTypes> response = new GeneralResponse<VaccineTypes>();
                if (VaccineTypes != null)
                {


                    _unitOfWork.VaccineTypes.Update(VaccineTypes);
                    response.Message = "The VaccineTypes Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(VaccineTypes);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update VaccineTypes";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this VaccineTypes are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyVaccineTypes
        /// <summary>
        /// Search for Specific VaccineTypes by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<VaccineTypes> response = new GeneralResponse<VaccineTypes>();

                VaccineTypes VaccineTypes = _unitOfWork.VaccineTypes.Search(k => k.VaccineTypeTittle == searchkey);
                if (VaccineTypes != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(VaccineTypes);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Not Found";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }


    }
}
#endregion
#endregion
#endregion