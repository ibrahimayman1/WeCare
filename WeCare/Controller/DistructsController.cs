﻿using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;
using System;

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
        public IActionResult GetDistructById(int id)
        {
            try {
                var distruct = _unitOfWork.Distructs.GetById(id);
                if (distruct == null)
                    throw new Exception("No Distructs is founnd with  id: " + id);
                return Ok(distruct);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Retrieves All Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllDistructs()
        {
            try
            {
                var Distructs = _unitOfWork.Distructs.GetAll();
                return Ok(Distructs);
            }
            catch (Exception ex)
            {
                return BadRequest("no Distructs Have been Added !");
            }

        }
        /// <summary>
        /// Delete specific Distructs by ID
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpDelete]
        public IActionResult DeleteDistruct(int id)
        {
            try
            {
                _unitOfWork.Distructs.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("no Distructs with  id:" + id);
            }
        }
        /// <summary>
        /// Add New Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPost]
        public IActionResult AddDistruct([FromQuery] DistructsCreateViewModel Distructs)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the Distructs correctly");
            }

        }

        /// <summary>
        /// Update Existing Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPut]
        public IActionResult UpdateDistruct(  Distructs Distructs)
        {
            try
            {
                _unitOfWork.Distructs.Update(Distructs);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct Distructs");
            }
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
            try
            {
                return Ok(_unitOfWork.Distructs.Search(k => k.DistrictTitle == searchkey));
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }

    }
}
