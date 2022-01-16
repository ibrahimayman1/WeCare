using bussinesslayer;
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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.VaccineTypes.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.VaccineTypes.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.VaccineTypes.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(VaccineTypes VaccineTypes)
        {
            _unitOfWork.VaccineTypes.Add(VaccineTypes);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int id, VaccineTypes VaccineTypes)
        {
            _unitOfWork.VaccineTypes.Update(VaccineTypes);
            return Ok();
        }
    }
}
