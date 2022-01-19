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
    public class DrugsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region  CRUD OPEARIONS

        #region GetDrugsById
        /// <summary>
        /// Retrieves a specific Drugs by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpGet("id")]
        public ActionResult<GeneralResponse<Drugs>> GetDrugsById(int id)
        {
            try
            {
                GeneralResponse<Drugs> response = new GeneralResponse<Drugs>();
                Drugs Drugs = _unitOfWork.Drugs.GetById(id);

                if (Drugs != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(Drugs);
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

        #region GetAllDrugs
        /// <summary>
        /// Retrieves All Drugs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllDrugs()
        {
            try
            {
                GeneralResponse<Drugs> response = new GeneralResponse<Drugs>();
                var Drugslst = _unitOfWork.Drugs.GetAll();

                if (Drugslst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data = _unitOfWork.Drugs.GetAll();
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
                return BadRequest("NO Drugs HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteDrugsById
        /// <summary>
        /// Delete specific Drugs by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>


        [HttpDelete]
        public IActionResult DeleteDrugs(int id)
        {
            try
            {
                GeneralResponse<Drugs> response = new GeneralResponse<Drugs>();
                Drugs Drugs = _unitOfWork.Drugs.GetById(id);

                if (Drugs != null)
                {
                    _unitOfWork.Drugs.Delete(id);
                    return Ok("The Drugs has Been Deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no Drugs with this id:" + id);
            }


        }
        #endregion




        #region AddDrugs

        /// <summary>
        /// Add New Drugs
        /// parameter (New Instance from Drugs )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpPost]
        public IActionResult AddDrugs([FromQuery] DrugsCreateViewModel Drugs)
        {

            try
            {
                GeneralResponse<Drugs> response = new GeneralResponse<Drugs>();
                if (Drugs != null)
                {
                    Drugs model = new Drugs()
                    {
                        DrugTitle = Drugs.DrugTitle,
                        DrugGroupID = Drugs.DrugGroupID,
                        CreationDate = Drugs.CreationDate
                    };
                    _unitOfWork.Drugs.Add(model);
                    response.Message = "The Drugs Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(model);
                    response.Success = true;

                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add Drugs";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the Drugs correctly  ");
            }
        }
        #endregion


        #region UpdateDrugs
        /// <summary>
        /// Update Existing Drugs
        ///   parameter (  Instance from Drugs )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpPut]

        public IActionResult UpdateDrugs([FromQuery] Drugs Drugs)
        {
            try
            {
                GeneralResponse<Drugs> response = new GeneralResponse<Drugs>();
                if (Drugs != null)
                {


                    _unitOfWork.Drugs.Update(Drugs);
                    response.Message = "The Drugs Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Drugs);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update Drugs";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this Drugs are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyDrugs
        /// <summary>
        /// Search for Specific Drugs by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<Drugs> response = new GeneralResponse<Drugs>();

                Drugs Drugs = _unitOfWork.Drugs.Search(k => k.DrugTitle == searchkey);
                if (Drugs != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Drugs);
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
