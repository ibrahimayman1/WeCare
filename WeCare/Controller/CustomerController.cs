using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motim_Data_Access_Layer.Models;
using System;

namespace WeCare.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
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
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var Customer = _unitOfWork.Customer.GetById(id);
                if(Customer == null)
                    throw new Exception("No Customer is founnd with  id: " + id);

                return Ok(Customer);
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
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customerLst = _unitOfWork.Customer.GetAll();
            if(customerLst == null)
                    return NoContent();
                return Ok(customerLst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _unitOfWork.Customer.Delete(id);
            }


            catch (Exception ex)
            {
                return BadRequest("no customer with  id:"+id);
            }
            return Ok();
        } 
        /// <summary>
        /// Add New Distructs
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Distructs created</response>
        /// <response code="400">Distructs has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Distructs right now</response>
        [HttpPost]
        public IActionResult AddCustomer([FromQuery] CustomerCreateViewModel Customer)
        {
            try
            {
                Customer model = new Customer()
                {
                    CustomerName = Customer.CustomerName,
                    CustomerNumber = Customer.CustomerNumber,
                    CustomerNumber2 = Customer.CustomerNumber2,
                    CustomerEmail = Customer.CustomerEmail,
                    ParentID = Customer.ParentID,
                    DistructID = Customer.DistructID,
                    CustomerNote = Customer.CustomerNote,
                    CustomerBirthDay = Customer.CustomerBirthDay,
                    CustomerAddress = Customer.CustomerAddress,


                    CustomerGender = Customer.CustomerGender
                };
                _unitOfWork.Customer.Add(model);
                return Ok(Customer);
            }
            catch (Exception ex)
            {
                return BadRequest("Please check that you  add the customer correctly");
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
        public IActionResult UpdateCustomer(Customer Customer)
        {
            try
            {
                _unitOfWork.Customer.Update(Customer);
                return Ok(Customer);
            }
            catch (Exception ex)
            {
                return BadRequest("Please check the you update the  correct customer");
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
