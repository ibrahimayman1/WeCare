using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

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
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.VaccineTypes.GetById(id));
        }
        /// <summary>
        /// Retrieves All VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.VaccineTypes.GetAll());
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
            _unitOfWork.VaccineTypes.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpPost]
        public IActionResult Add(VaccineTypesCreateViewModel VaccineTypes)
        {
            VaccineTypes model = new VaccineTypes()
            {
                VaccineTypeTittle = VaccineTypes.VaccineTypeTittle,
                
                CreationDate = VaccineTypes.CreationDate
            };
            _unitOfWork.VaccineTypes.Add(model);
            return Ok();
        }
        /// <summary>
        /// Update Existing VaccineTypes
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpPut]
        public IActionResult Update( VaccineTypes VaccineTypes)
        {
            _unitOfWork.VaccineTypes.Update(VaccineTypes);
            return Ok();
        }
        /// <summary>
        /// Search for Specific cit by using SearchKey
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">VaccineTypes created</response>
        /// <response code="400">VaccineTypes has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your VaccineTypes right now</response>
        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            return Ok(_unitOfWork.VaccineTypes.Search(k => k.VaccineTypeTittle == searchkey));
        }
    }
}
