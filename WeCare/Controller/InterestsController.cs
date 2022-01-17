using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

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
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Interests.GetById(id));
        }
        /// <summary>
        /// Retrieves All Interests
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Interests.GetAll());
        }
        /// <summary>
        /// Delete specific DrugsGroups by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">DrugsGroups created</response>
        /// <response code="400">DrugsGroups has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your DrugsGroups right now</response>
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.Interests.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New Interests
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpPost]
        public IActionResult Add(InterestsCreateViewModel Interests)
        {
            Interests model = new Interests()
            {
                InterestsTittle = Interests.InterestsTittle,
                CreationDate = Interests.CreationDate
            };
            _unitOfWork.Interests.Add(model);
            return Ok();
        }
        /// <summary>
        /// Update Existing Interests
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Interests created</response>
        /// <response code="400">Interests has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Interests right now</response>
        [HttpPut]
        public IActionResult Update( Interests Interests)
        {
            _unitOfWork.Interests.Update( Interests);
            return Ok();
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
            return Ok(_unitOfWork.Interests.Search(k => k.InterestsTittle == searchkey));
        }
    }
}
