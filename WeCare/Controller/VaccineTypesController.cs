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
    public class VaccineTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VaccineTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("id")]
        public IActionResult GetVaccineTypesById(int id)
        {
            try
            {
                var VaccineTypes = _unitOfWork.VaccineTypes.GetById(id);
                if(VaccineTypes == null)
                    throw new Exception("No VaccineTypes is founnd with  id: " + id);

                return Ok(VaccineTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Retrieves All VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>

        [HttpGet("GetAll")]
        public IActionResult VaccineTypesGetAll()
        {
            try
            {
                var vaccineTypes = _unitOfWork.VaccineTypes.GetAll();
                if(vaccineTypes==null)
                    return NoContent();
                return Ok(vaccineTypes);
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
        public IActionResult DeleteVaccineTypes(int id)
        {
            try
            {
                _unitOfWork.VaccineTypes.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Deleted Action Not complete no VaccineType with this id:" + id);
            }
        }
        /// <summary>
        /// Add New VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpPost]
        public IActionResult AddVaccineTypes(VaccineTypesCreateViewModel VaccineTypes)
        {
            try
            {
                VaccineTypes model = new VaccineTypes()
                {
                    VaccineTypeTittle = VaccineTypes.VaccineTypeTittle,

                    CreationDate = VaccineTypes.CreationDate
                };
                _unitOfWork.VaccineTypes.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the VaccineType correctly");
            }
        }
        /// <summary>
        /// Update Existing VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpPut]
        public IActionResult UpdateVaccineTypes( VaccineTypes VaccineTypes)
        {
            try
            {
                _unitOfWork.VaccineTypes.Update(VaccineTypes);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct VaccineTypes");
            }
        }
        /// <summary>
        /// Search for Specific VaccineTypes by using SearchKey
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try {
                return Ok(_unitOfWork.VaccineTypes.Search(k => k.VaccineTypeTittle == searchkey));
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }
    }
}
