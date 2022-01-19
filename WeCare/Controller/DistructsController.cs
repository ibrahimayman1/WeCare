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
    public class DistructsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistructsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region  CRUD OPEARIONS

        #region GetDistructsById
        /// <summary>
        /// Retrieves a specific Distructs by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpGet("id")]
        public ActionResult<GeneralResponse<Distructs>> GetDistructsById(int id)
        {
            try
            {
                GeneralResponse<Distructs> response = new GeneralResponse<Distructs>();
                Distructs Distructs = _unitOfWork.Distructs.GetById(id);

                if (Distructs != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(Distructs);
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

        #region GetAllDistructs
        /// <summary>
        /// Retrieves All Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllDistructs()
        {
            try
            {
                GeneralResponse<Distructs> response = new GeneralResponse<Distructs>();
                var Distructslst = _unitOfWork.Distructs.GetAll();

                if (Distructslst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data = _unitOfWork.Distructs.GetAll();
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
                return BadRequest("NO Distructs HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteDistructsById
        /// <summary>
        /// Delete specific Distructs by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>


        [HttpDelete]
        public IActionResult DeleteDistructs(int id)
        {
            try
            {
                GeneralResponse<Distructs> response = new GeneralResponse<Distructs>();
                Distructs Distructs = _unitOfWork.Distructs.GetById(id);

                if (Distructs != null)
                {
                    _unitOfWork.Distructs.Delete(id);
                    return Ok("The Distructs has Been Deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no Distructs with this id:" + id);
            }


        }
        #endregion




        #region AddDistructs

        /// <summary>
        /// Add New Distructs
        /// parameter (New Instance from Distructs )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPost]
        public IActionResult AddDistructs([FromQuery] DistructsCreateViewModel Distructs)
        {

            try
            {
                GeneralResponse<Distructs> response = new GeneralResponse<Distructs>();
                if (Distructs != null)
                {
                    Distructs model = new Distructs()
                    {
                        DistrictTitle = Distructs.DistrictTitle,
                        CityID = Distructs.CityID,
                        CreationDate = Distructs.CreationDate

                    };
                    _unitOfWork.Distructs.Add(model);
                    response.Message = "The Distructs Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(model);
                    response.Success = true;

                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add Distructs";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the Distructs correctly  ");
            }
        }
        #endregion


        #region UpdateDistructs
        /// <summary>
        /// Update Existing Distructs
        ///   parameter (  Instance from Distructs )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPut]

        public IActionResult UpdateDistructs([FromQuery] Distructs Distructs)
        {
            try
            {
                GeneralResponse<Distructs> response = new GeneralResponse<Distructs>();
                if (Distructs != null)
                {


                    _unitOfWork.Distructs.Update(Distructs);
                    response.Message = "The Distructs Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Distructs);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update Distructs";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this Distructs are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyDistructs
        /// <summary>
        /// Search for Specific Distructs by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<Distructs> response = new GeneralResponse<Distructs>();

                Distructs Distructs = _unitOfWork.Distructs.Search(k => k.DistrictTitle == searchkey);
                if (Distructs != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Distructs);
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
