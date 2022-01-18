using bussinesslayer;
using DataAccsess_Layer.ViewModel;
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
        /// <summary>
        /// Retrieves a specific DrugsGroups by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpGet("id")]
        public IActionResult GetDrugsGroupsById(int id)
        {
            try
            {
                var DrugsGroups = _unitOfWork.DrugsGroups.GetById(id);
                if (DrugsGroups == null)
                    throw new Exception("No DrugsGroups is founnd with  id: " + id);
                return Ok(DrugsGroups);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
                var DrugsGroup = _unitOfWork.DrugsGroups.GetAll();
                if (DrugsGroup == null)
                    return NoContent();
                return Ok(DrugsGroup);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Delete specific DrugsGroups by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpDelete]
        public IActionResult DeleteDrugsGroup(int id)
        {
            try
            {
                _unitOfWork.DrugsGroups.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Deleted Action Not complete no DrugsGroups with  id:" + id);
            }
        }
        /// <summary>
        /// Add New DrugsGroups
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpPost]
        public IActionResult AddDrugsGroup([FromQuery] DrugsGroupsCreateViewModel DrugsGroups)
        {
            try
            {
                DrugsGroups model = new DrugsGroups()
                {
                    GroupTittle = DrugsGroups.GroupTittle,
                    CreationTime = DrugsGroups.CreationTime
                };
                _unitOfWork.DrugsGroups.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the DrugsGroups correctly");
            }

        }
        /// <summary>
        /// Update Existing DrugsGroups
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpPut]
        public IActionResult UpdateDrugsGroup(  DrugsGroups DrugsGroups)
        {
            try
            {
                _unitOfWork.DrugsGroups.Update(DrugsGroups);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct DrugsGroups");
            }
        }
        /// <summary>
        /// Search for Specific cit by using SearchKey
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
                return Ok(_unitOfWork.DrugsGroups.Search(k => k.GroupTittle == searchkey));
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }
    }
}
