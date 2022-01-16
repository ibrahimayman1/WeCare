using bussinesslayer;
using DataAccsess_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;

namespace WeCare.CityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase

    {
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.city.GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.city.GetAll());
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            _unitOfWork.city.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(insertCity city)
        {
            City model = new City()
            {
                CityTittle = city.CityTittle,
                CreationDate = city.CreationDate
            };
            _unitOfWork.city.Add(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update( City city)
        {
            _unitOfWork.city.Update(city);
            return Ok();
        }




    }
}
