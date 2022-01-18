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
    public class InterestsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public InterestsController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Retrieves a specific Interests by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpGet("id")]
        public IActionResult GetInterestsById(int id)
        {
            try {
                var Interest = _unitOfWork.Interests.GetById(id);
                if(Interest == null)
                    throw new Exception("No DrugsGroups is founnd with  id: " + id);
                return Ok(Interest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Retrieves All Interests
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllInterests()
        {
            try
            {
                var Interests= _unitOfWork.Interests.GetAll();
                if(Interests == null)
                    return NoContent();
                return Ok(Interests);
            }
            catch (Exception ex)
            {
                return BadRequest("no Interests Have been Added !");
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
        public IActionResult DeleteInterest(int id)
        {
            try
            {
                _unitOfWork.Interests.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Deleted Action Not complete no Interests with this id:" + id);
            }
        }
        /// <summary>
        /// Add New Interests
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpPost]
        public IActionResult AddInterest(InterestsCreateViewModel Interests)
        {
            try
            {
                Interests model = new Interests()
                {
                    InterestsTittle = Interests.InterestsTittle,
                    CreationDate = Interests.CreationDate
                };
                _unitOfWork.Interests.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the Distructs correctly");
            }
        }
        /// <summary>
        /// Update Excisting intrest
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpPut]
        public IActionResult UpdateInterest( Interests Interests)
        {
            try
            {
                _unitOfWork.Interests.Update(Interests);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct Distructs");
            }
        }
        /// <summary>
        /// Search for Specific Interests by using SearchKey
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {

                return Ok(_unitOfWork.Interests.Search(k => k.InterestsTittle == searchkey));
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }
    }
}
