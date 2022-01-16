using bussinesslayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

namespace WeCare.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsGroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugsGroupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.DrugsGroups.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.DrugsGroups.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.DrugsGroups.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(DrugsGroups DrugsGroups)
        {
            _unitOfWork.DrugsGroups.Add(DrugsGroups);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update( int id, DrugsGroups DrugsGroups)
        {
            _unitOfWork.DrugsGroups.Update( DrugsGroups);
            return Ok();
        }
    }
}
