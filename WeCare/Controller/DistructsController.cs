using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

namespace WeCare.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistructsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistructsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Retrieves a specific Distructs by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Distructs.GetById(id));
        }
        /// <summary>
        /// Retrieves All Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Distructs.GetAll());
        }
        /// <summary>
        /// Delete specific Distructs by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Distructs.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPost]
        public IActionResult Add([FromQuery] DistructsCreateViewModel Distructs)
        {
            Distructs model = new Distructs()
            {
                DistrictTitle = Distructs.DistrictTitle,
                CityID = Distructs.CityID,
                CreationDate = Distructs.CreationDate

            };
            _unitOfWork.Distructs.Add(model);
            return Ok();
        }
        /// <summary>
        /// Update Existing Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPut]
        public IActionResult Update(  Distructs Distructs)
        {
            _unitOfWork.Distructs.Update( Distructs);
            return Ok();
        }
        /// <summary>
        /// Search for Specific cit by using SearchKey
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            return Ok(_unitOfWork.Distructs.Search(k => k.DistrictTitle == searchkey));
        }

    }
}
