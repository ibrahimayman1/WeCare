using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

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
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Vaccancies.GetById(id));
        }
        /// <summary>
        /// Retrieves All Vaccancies
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Vaccancies.GetAll());
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
            _unitOfWork.Vaccancies.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New Vaccancies
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpPost]
        public IActionResult Add(VaccanciesCreateViewModel Vaccancies)
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
        /// <summary>
        /// Update Existing Vaccancies
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Vaccancies created</response>
        /// <response code="400">Vaccancies has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Vaccancies right now</response>
        [HttpPut]
        public IActionResult Update( Vaccancies Vaccancies)
        {
            _unitOfWork.Vaccancies.Update( Vaccancies);
            return Ok();
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
            return Ok(_unitOfWork.Vaccancies.Search(k => k.VaccineTittle == searchkey));
        }
    }
}
