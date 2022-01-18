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
    public class VaccanciesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccanciesController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Retrieves a specific Vaccancies by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpGet("id")]
        public IActionResult GetVaccanciesById(int id)
        {
            try
            {
                var Vaccancies = _unitOfWork.Vaccancies.GetById(id);
                if(Vaccancies == null)
                    throw new Exception("No Vaccancies is founnd with  id: " + id);
                return Ok(Vaccancies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
                var Vaccancies = _unitOfWork.Vaccancies.GetAll();
                if(Vaccancies == null)
                    return NoContent();
                return Ok(Vaccancies);
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
        public IActionResult deleteVaccancies(int id)
        {
            try
            {
                _unitOfWork.Vaccancies.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Deleted Action Not complete no Vaccancie with this id:" + id);
            }
        }
        /// <summary>
        /// Add New Vaccancies
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpPost]
        public IActionResult AddVaccancies(VaccanciesCreateViewModel Vaccancies)
        {
            try
            {
                Vaccancies model = new Vaccancies()
                {
                    VaccineTittle = Vaccancies.VaccineTittle,
                    VaccineMonths = Vaccancies.VaccineMonths,
                    CreationDate = Vaccancies.CreationDate
                };
                _unitOfWork.Vaccancies.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the Vaccancie correctly");
            }
        }
        /// <summary>
        /// Update Existing Vaccancies
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpPut]
        public IActionResult UpdateVaccancie(Vaccancies Vaccancies)
        {
            try
            {
                _unitOfWork.Vaccancies.Update(Vaccancies);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct Vaccancies");
            }
        }
        /// <summary>
        /// Search for Specific cit by using SearchKey
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
                return Ok(_unitOfWork.Vaccancies.Search(k => k.VaccineTittle == searchkey));
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        } 
    }
}
