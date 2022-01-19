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
    public class DrugsGroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugsGroupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    #region  CRUD OPEARIONS

            #region GetDrugsGroupsById
        /// <summary>
        /// Retrieves a specific DrugsGroups by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpGet("id")]
        public ActionResult< GeneralResponse<DrugsGroups>>  GetDrugsGroupsById(int id)
        {
            try
            {
                GeneralResponse<DrugsGroups> response = new GeneralResponse<DrugsGroups>();
                DrugsGroups DrugsGroups = _unitOfWork.DrugsGroups.GetById(id);

                if (DrugsGroups != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(DrugsGroups);
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

            #region GetAllDrugsGroups
        /// <summary>
        /// Retrieves All DrugsGroups
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllDrugsGroups()
        {
            try
            {
                GeneralResponse<DrugsGroups> response = new GeneralResponse<DrugsGroups>();
                var DrugsGroupslst = _unitOfWork.DrugsGroups.GetAll();

                if (DrugsGroupslst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data =_unitOfWork.DrugsGroups.GetAll() ;
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
                return BadRequest("NO DrugsGroups HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteDrugsGroupsById
        /// <summary>
        /// Delete specific DrugsGroups by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
       

        [HttpDelete]
        public IActionResult DeleteDrugsGroups(int id)
        {
            try
            {
                GeneralResponse<DrugsGroups> response = new GeneralResponse<DrugsGroups>();
                DrugsGroups DrugsGroups = _unitOfWork.DrugsGroups.GetById(id);
              
                if (DrugsGroups != null)
                {
                    _unitOfWork.DrugsGroups.Delete(id);
                    return Ok("The DrugsGroups has Been Deleted");
                }
                else
                {
                    return NotFound();  
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no DrugsGroups with this id:" + id);
            }


        }
        #endregion




        #region AddDrugsGroups

        /// <summary>
        /// Add New DrugsGroups
        /// parameter (New Instance from DrugsGroups )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpPost]
        public IActionResult AddDrugsGroups([FromQuery] DrugsGroupsCreateViewModel DrugsGroups)
        {

            try
            {
                GeneralResponse<DrugsGroups> response = new GeneralResponse<DrugsGroups>();
                if (DrugsGroups != null)
                {
                    DrugsGroups model = new DrugsGroups()
                    {
                        GroupTittle = DrugsGroups.GroupTittle,
                        CreationTime = DrugsGroups.CreationTime
                    };
                    _unitOfWork.DrugsGroups.Add(model);
                    response.Message = "The DrugsGroups Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    
                    response.Data.Add(model);
                    response.Success = true;
                    
                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add DrugsGroups";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the DrugsGroups correctly  ");
            }
        }
        #endregion


        #region UpdateDrugsGroups
        /// <summary>
        /// Update Existing DrugsGroups
        ///   parameter (  Instance from DrugsGroups )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpPut]

        public IActionResult UpdateDrugsGroups([FromQuery] DrugsGroups DrugsGroups)
        {
            try
            {
                GeneralResponse<DrugsGroups> response = new GeneralResponse<DrugsGroups>();
                if (DrugsGroups != null)
                {
                    

                    _unitOfWork.DrugsGroups.Update(DrugsGroups);
                    response.Message = "The DrugsGroups Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(DrugsGroups);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update DrugsGroups";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this DrugsGroups are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyDrugsGroups
        /// <summary>
        /// Search for Specific DrugsGroups by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<DrugsGroups> response = new GeneralResponse<DrugsGroups>();

                DrugsGroups DrugsGroups = _unitOfWork.DrugsGroups.Search(k => k.GroupTittle == searchkey);
                if (DrugsGroups != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(DrugsGroups);
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