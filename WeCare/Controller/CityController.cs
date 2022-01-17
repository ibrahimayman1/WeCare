using bussinesslayer;
using DataAccsess_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;
using System;

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
        /// <summary>
        /// Retrieves a specific city by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            
                return Ok(_unitOfWork.city.GetById(id));
            
          
        }
        /// <summary>
        /// Retrieves All City
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.city.GetAll());
        }
        /// <summary>
        /// Delete specific city by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.city.Delete(id);
            return Ok();
        }
        /// <summary>
        /// Add New City
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpPost]
        public IActionResult Add([FromQuery]CityCreateViewModel city)
        {
            City model = new City()
            {
                CityTittle = city.CityTittle,
                CreationDate = city.CreationDate
            };
            _unitOfWork.city.Add(model);
            return Ok(model);
        }
        /// <summary>
        /// Update Existing City
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>
        [HttpPut]
        public IActionResult Update([FromQuery] City city)
        {

            _unitOfWork.city.Update(city);
            return Ok();
        }
        /// <summary>
        /// Search for Specific city by using SearchKey
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">City created</response>
        /// <response code="400">City has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your City right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            return Ok(_unitOfWork.city.Search(k=>k.CityTittle== searchkey));
        }


    }
}
