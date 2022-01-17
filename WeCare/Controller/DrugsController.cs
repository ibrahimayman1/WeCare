using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

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
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Drugs.GetById(id));
        }
        /// <summary>
        /// Retrieves All Drugs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Drugs.GetAll());
        }
        /// <summary>
        /// Delete specific Drugs by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.Drugs.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New Drugs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpPost]
        public IActionResult Add([FromQuery] DrugsCreateViewModel Drugs)
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
        /// <summary>
        /// Update Existing Drugs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Drugs created</response>
        /// <response code="400">Drugs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Drugs right now</response>
        [HttpPut]
        public IActionResult Update( Drugs Drugs)
        {
            _unitOfWork.Drugs.Update( Drugs);
            return Ok();
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
            return Ok(_unitOfWork.Drugs.Search(k => k.DrugTitle == searchkey));
        }
    }
}
