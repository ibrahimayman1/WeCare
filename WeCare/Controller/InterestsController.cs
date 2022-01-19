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
    public class InterestsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public InterestsController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        #region  CRUD OPEARIONS

        #region GetInterestsById
        /// <summary>
        /// Retrieves a specific Interests by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpGet("id")]
        public ActionResult<GeneralResponse<Interests>> GetInterestsById(int id)
        {
            try
            {
                GeneralResponse<Interests> response = new GeneralResponse<Interests>();
                Interests Interests = _unitOfWork.Interests.GetById(id);

                if (Interests != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(Interests);
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

        #region GetAllInterests
        /// <summary>
        /// Retrieves All Interests
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllInterests()
        {
            try
            {
                GeneralResponse<Interests> response = new GeneralResponse<Interests>();
                var Interestslst = _unitOfWork.Interests.GetAll();

                if (Interestslst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data = _unitOfWork.Interests.GetAll();
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
                return BadRequest("NO Interests HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteInterestsById
        /// <summary>
        /// Delete specific Interests by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>


        [HttpDelete]
        public IActionResult DeleteInterests(int id)
        {
            try
            {
                GeneralResponse<Interests> response = new GeneralResponse<Interests>();
                Interests Interests = _unitOfWork.Interests.GetById(id);

                if (Interests != null)
                {
                    _unitOfWork.Interests.Delete(id);
                    return Ok("The Interests has Been Deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no Interests with this id:" + id);
            }


        }
        #endregion




        #region AddInterests

        /// <summary>
        /// Add New Interests
        /// parameter (New Instance from Interests )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpPost]
        public IActionResult AddInterests([FromQuery] InterestsCreateViewModel Interests)
        {

            try
            {
                GeneralResponse<Interests> response = new GeneralResponse<Interests>();
                if (Interests != null)
                {
                    Interests model = new Interests()
                    {
                        InterestsTittle = Interests.InterestsTittle,
                        CreationDate = Interests.CreationDate
                    };
                    _unitOfWork.Interests.Add(model);
                    response.Message = "The Interests Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(model);
                    response.Success = true;

                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add Interests";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the Interests correctly  ");
            }
        }
        #endregion


        #region UpdateInterests
        /// <summary>
        /// Update Existing Interests
        ///   parameter (  Instance from Interests )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpPut]

        public IActionResult UpdateInterests([FromQuery] Interests Interests)
        {
            try
            {
                GeneralResponse<Interests> response = new GeneralResponse<Interests>();
                if (Interests != null)
                {


                    _unitOfWork.Interests.Update(Interests);
                    response.Message = "The Interests Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Interests);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update Interests";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this Interests are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyInterests
        /// <summary>
        /// Search for Specific Interests by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<Interests> response = new GeneralResponse<Interests>();

                Interests Interests = _unitOfWork.Interests.Search(k => k.InterestsTittle == searchkey);
                if (Interests != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Interests);
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