using bussinesslayer;
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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Vaccancies.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Vaccancies.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.Vaccancies.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Vaccancies Vaccancies)
        {
            _unitOfWork.Vaccancies.Add(Vaccancies);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int id, Vaccancies Vaccancies)
        {
            _unitOfWork.Vaccancies.Update( Vaccancies);
            return Ok();
        }
    }
}
