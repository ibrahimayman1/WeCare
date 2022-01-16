using bussinesslayer;
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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Drugs.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Drugs.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.Drugs.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Drugs Drugs)
        {
            _unitOfWork.Drugs.Add(Drugs);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int id, Drugs Drugs)
        {
            _unitOfWork.Drugs.Update( Drugs);
            return Ok();
        }
    }
}
