using bussinesslayer;
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
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Distructs.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Distructs.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.Distructs.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(Distructs Distructs)
        {
            _unitOfWork.Distructs.Add(Distructs);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update( int id, Distructs Distructs)
        {
            _unitOfWork.Distructs.Update( Distructs);
            return Ok();
        }

    }
}
