using bussinesslayer;
using DataAccsess_Layer.Models;
using DataAccsess_Layer.ViewModel.GeneralResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;
using System;

namespace WeCare.CityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase

    {

        #region Declare Variables
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CityController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        #endregion

        #region  CRUD OPEARIONS

            #region GetCityById
        /// <summary>
        /// Retrieves a specific city by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpGet("id")]
        public ActionResult< GeneralResponse<City>>  GetCityById(int id)
        {
            try
            {
                GeneralResponse<City> response = new GeneralResponse<City>();
                City city = _unitOfWork.city.GetById(id);

                if (city != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(city);
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

            #region GetAllCity
        /// <summary>
        /// Retrieves All City
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllCity()
        {
            try
            {
                GeneralResponse<City> response = new GeneralResponse<City>();
                var Citylst = _unitOfWork.city.GetAll();

                if (Citylst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data =_unitOfWork.city.GetAll() ;
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
                return BadRequest("NO CITY HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeletecityById
        /// <summary>
        /// Delete specific city by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
       

        [HttpDelete]
        public IActionResult DeleteCity(int id)
        {
            try
            {
                GeneralResponse<City> response = new GeneralResponse<City>();
                City city = _unitOfWork.city.GetById(id);
              
                if (city != null)
                {
                    _unitOfWork.city.Delete(id);
                    return Ok("The city has Been Deleted");
                }
                else
                {
                    return NotFound();  
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no CITY with this id:" + id);
            }


        }
        #endregion




        #region AddCity

        /// <summary>
        /// Add New City
        /// parameter (New Instance from city )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpPost]
        public IActionResult AddCity([FromQuery] CityCreateViewModel city)
        {

            try
            {
                GeneralResponse<City> response = new GeneralResponse<City>();
                if (city != null)
                {
                    City model = new City()
                    {
                        CityTittle = city.CityTittle,
                      
                        CreationDate = city.CreationDate
                    };
                    _unitOfWork.city.Add(model);
                    response.Message = "The city Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    
                    response.Data.Add(model);
                    response.Success = true;
                    
                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add City";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the city correctly  ");
            }
        }
        #endregion


        #region UpdateCity
        /// <summary>
        /// Update Existing City
        ///   parameter (  Instance from city )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpPut]

        public IActionResult UpdateCity([FromQuery] City city)
        {
            try
            {
                GeneralResponse<City> response = new GeneralResponse<City>();
                if (city != null)
                {
                    

                    _unitOfWork.city.Update(city);
                    response.Message = "The city Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(city);
                    response.Success = true;
                    return Ok(city);
                }
                else
                {
                    response.Message = "Failed To Update City";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this city are exist  ");
            }
        }

        #endregion

        #endregion

        #region  Search

        #region  Searchbycity
        /// <summary>
        /// Search for Specific city by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                return Ok(_unitOfWork.city.Search(k => k.CityTittle == searchkey));
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