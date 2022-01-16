using bussinesslayer;
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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Interests.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Interests.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.Interests.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Interests Interests)
        {
            _unitOfWork.Interests.Add(Interests);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int id, Interests Interests)
        {
            _unitOfWork.Interests.Update( Interests);
            return Ok();
        }
    }
}
