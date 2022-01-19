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
    public class VaccanciesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccanciesController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
    #region  CRUD OPEARIONS

            #region GetVaccanciesById
        /// <summary>
        /// Retrieves a specific Vaccancies by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpGet("id")]
        public ActionResult< GeneralResponse<Vaccancies>>  GetVaccanciesById(int id)
        {
            try
            {
                GeneralResponse<Vaccancies> response = new GeneralResponse<Vaccancies>();
                Vaccancies Vaccancies = _unitOfWork.Vaccancies.GetById(id);

                if (Vaccancies != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(Vaccancies);
                    response.Success = true;


                    return response;
                }
                else
                {
                    response.Message = "Failed To Retrive Data";
                    response.StatusCode = HttpContext.Response.StatusCode=400;
                  
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

            #region GetAllVaccancies
        /// <summary>
        /// Retrieves All Vaccancies
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllVaccancies()
        {
            try
            {
                GeneralResponse<Vaccancies> response = new GeneralResponse<Vaccancies>();
                var Vaccancieslst = _unitOfWork.Vaccancies.GetAll();

                if (Vaccancieslst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data =_unitOfWork.Vaccancies.GetAll() ;
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
                return BadRequest("NO Vaccancies HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteVaccanciesById
        /// <summary>
        /// Delete specific Vaccancies by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
       

        [HttpDelete]
        public IActionResult DeleteVaccancies(int id)
        {
            try
            {
                GeneralResponse<Vaccancies> response = new GeneralResponse<Vaccancies>();
                Vaccancies Vaccancies = _unitOfWork.Vaccancies.GetById(id);
              
                if (Vaccancies != null)
                {
                    _unitOfWork.Vaccancies.Delete(id);
                    return Ok("The Vaccancies has Been Deleted");
                }
                else
                {
                    return NotFound();  
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no Vaccancies with this id:" + id);
            }


        }
        #endregion




        #region AddVaccancies

        /// <summary>
        /// Add New Vaccancies
        /// parameter (New Instance from Vaccancies )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpPost]
        public IActionResult AddVaccancies([FromQuery] VaccanciesCreateViewModel Vaccancies)
        {

            try
            {
                GeneralResponse<Vaccancies> response = new GeneralResponse<Vaccancies>();
                if (Vaccancies != null)
                {
                    Vaccancies model = new Vaccancies()
                    {
                        VaccineTittle = Vaccancies.VaccineTittle,
                        VaccineMonths = Vaccancies.VaccineMonths,
                        CreationDate = Vaccancies.CreationDate
                    };
                    _unitOfWork.Vaccancies.Add(model);
                    response.Message = "The Vaccancies Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    
                    response.Data.Add(model);
                    response.Success = true;
                    
                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add Vaccancies";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the Vaccancies correctly  ");
            }
        }
        #endregion


        #region UpdateVaccancies
        /// <summary>
        /// Update Existing Vaccancies
        ///   parameter (  Instance from Vaccancies )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpPut]

        public IActionResult UpdateVaccancies([FromQuery] Vaccancies Vaccancies)
        {
            try
            {
                GeneralResponse<Vaccancies> response = new GeneralResponse<Vaccancies>();
                if (Vaccancies != null)
                {
                    

                    _unitOfWork.Vaccancies.Update(Vaccancies);
                    response.Message = "The Vaccancies Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Vaccancies);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update Vaccancies";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this Vaccancies are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyVaccancies
        /// <summary>
        /// Search for Specific Vaccancies by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<Vaccancies> response = new GeneralResponse<Vaccancies>();

                Vaccancies Vaccancies = _unitOfWork.Vaccancies.Search(k => k.VaccineTittle == searchkey);
                if (Vaccancies != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Vaccancies);
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