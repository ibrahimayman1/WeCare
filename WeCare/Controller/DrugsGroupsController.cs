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
        public IActionResult GetById(int id)
        {
            try
            {

                return Ok(_unitOfWork.DrugsGroups.GetById(id));
            }

            catch (Exception ex)
            {

                return BadRequest(ex.InnerException);
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
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.DrugsGroups.GetAll());
        }
        /// <summary>
        /// Delete specific DrugsGroups by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.DrugsGroups.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New DrugsGroups
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpPost]
        public IActionResult Add([FromQuery] DrugsGroupsCreateViewModel DrugsGroups)
        {
            DrugsGroups model = new DrugsGroups()
            {
                GroupTittle = DrugsGroups.GroupTittle,
                CreationTime = DrugsGroups.CreationTime
            };
            _unitOfWork.DrugsGroups.Add(model);
            return Ok();
        }
        /// <summary>
        /// Update Existing DrugsGroups
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpPut]
        public IActionResult Update(  DrugsGroups DrugsGroups)
        {
            _unitOfWork.DrugsGroups.Update( DrugsGroups);
            return Ok();
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
            return Ok(_unitOfWork.DrugsGroups.Search(k => k.GroupTittle == searchkey));
        }
    }
}
