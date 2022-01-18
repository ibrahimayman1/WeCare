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
    public class DrugsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Retrieves a specific Drugs by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpGet("id")]
        public IActionResult GetDrugsById(int id)
        {
            try
            {
                var Drug = _unitOfWork.Drugs.GetById(id);
                if(Drug == null)
                    throw new Exception("No Drugs is founnd with  id: " + id);
                return Ok(Drug);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
                var Drugs= _unitOfWork.Drugs.GetAll();
                if(Drugs == null)
                    return NoContent();
                return Ok(Drugs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Delete specific Drugs by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpDelete]
        public IActionResult DeleteDrugbyId(int id)
        {
            try
            {
                _unitOfWork.Drugs.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Deleted Action Not complete no Drugs with this id:" + id);
            }
        }
        /// <summary>
        /// Add New Drugs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpPost]
        public IActionResult AddDrug([FromQuery] DrugsCreateViewModel Drugs)
        {
            try
            {
                Drugs model = new Drugs()
            {
                DrugTitle = Drugs.DrugTitle,
                DrugGroupID = Drugs.DrugGroupID,
                CreationDate = Drugs.CreationDate
            };
            _unitOfWork.Drugs.Add(model);
            return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the Drugs correctly");
            }
        }
        /// <summary>
        /// Update Existing Drugs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpPut]
        public IActionResult UpdateDrug( Drugs Drugs)
        {
            try
            {
                _unitOfWork.Drugs.Update(Drugs);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct Distructs");
            }

        }
        /// <summary>
        /// Search for Specific cit by using SearchKey
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
                return Ok(_unitOfWork.Drugs.Search(k => k.DrugTitle == searchkey));
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }
    }
}
