using bussinesslayer;
using DataAccsess_Layer.ViewModel;
using DataAccsess_Layer.ViewModel.GeneralResponse;
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
        #region Declare Variables
        private readonly IUnitOfWork _unitOfWork;


        #endregion


        #region Constructor
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region  CRUD OPEARIONS

        #region GetCustomerById
        /// <summary>
        /// Retrieves a specific Customer by unique id
        ///  parameter (ID)
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Customer created</response>
        /// <response code="400">Customer has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Customer right now</response>
        [HttpGet("id")]
        public ActionResult<GeneralResponse<Customer>> GetCustomerById(int id)
        {
            try
            {
                GeneralResponse<Customer> response = new GeneralResponse<Customer>();
                Customer Customer = _unitOfWork.Customer.GetById(id);

                if (Customer != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data.Add(Customer);
                    response.Success = true;


                    return response;
                }
                else
                {
                    response.Message = "Failed To Retrive Data";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region GetAllCustomer
        /// <summary>
        /// Retrieves All Customer
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Customer created</response>
        /// <response code="400">Customer has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Customer right now</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllCustomer()
        {
            try
            {
                GeneralResponse<Customer> response = new GeneralResponse<Customer>();
                var Customerlst = _unitOfWork.Customer.GetAll();

                if (Customerlst != null)
                {
                    response.Message = "Success";
                    response.StatusCode = HttpContext.Response.StatusCode;
                    response.Data = _unitOfWork.Customer.GetAll();
                    response.Success = true;


                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Retrive Data";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }

            catch (Exception ex)
            {
                return BadRequest("NO Customer HAS BEEN ADDED in your Data Base");
            }
        }
        #endregion



        #region DeleteCustomerById
        /// <summary>
        /// Delete specific Customer by ID
        /// parameter (int )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Customer created</response>
        /// <response code="400">Customer has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Customer right now</response>


        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                GeneralResponse<Customer> response = new GeneralResponse<Customer>();
                Customer Customer = _unitOfWork.Customer.GetById(id);

                if (Customer != null)
                {
                    _unitOfWork.Customer.Delete(id);
                    return Ok("The Customer has Been Deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("no Customer with this id:" + id);
            }


        }
        #endregion




        #region AddCustomer

        /// <summary>
        /// Add New Customer
        /// parameter (New Instance from Customer )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Customer created</response>
        /// <response code="400">Customer has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Customer right now</response>
        [HttpPost]
        public IActionResult AddCustomer([FromQuery] CustomerCreateViewModel Customer)
        {

            try
            {
                GeneralResponse<Customer> response = new GeneralResponse<Customer>();
                if (Customer != null)
                {
                    Customer model = new Customer()
                    {
                        CustomerName = Customer.CustomerName,

                        CustomerEmail = Customer.CustomerEmail,
                        CustomerNumber = Customer.CustomerNumber,
                        CustomerNumber2 = Customer.CustomerNumber2,
                        CustomerGender = Customer.CustomerGender,
                        CustomerBirthDay = Customer.CustomerBirthDay,
                        CustomerNote = Customer.CustomerNote,
                        DistructID = Customer.DistructID,
                        CustomerAddress = Customer.CustomerAddress,
                        ParentID = Customer.ParentID
                      

                    };
                    _unitOfWork.Customer.Add(model);
                    response.Message = "The Customer Has Been Add";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(model);
                    response.Success = true;

                    return Ok(response);

                }
                else
                {
                    response.Message = "Failed To Add Customer";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }


            catch (Exception ex)
            {
                return BadRequest("Please add the Customer correctly  ");
            }
        }
        #endregion


        #region UpdateCustomer
        /// <summary>
        /// Update Existing Customer
        ///   parameter (  Instance from Customer )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Customer created</response>
        /// <response code="400">Customer has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Customer right now</response>
        [HttpPut]

        public IActionResult UpdateCustomer([FromQuery] Customer Customer)
        {
            try
            {
                GeneralResponse<Customer> response = new GeneralResponse<Customer>();
                if (Customer != null)
                {


                    _unitOfWork.Customer.Update(Customer);
                    response.Message = "The Customer Has Been Updated";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Customer);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Failed To Update Customer";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Please ckeck if this Customer are exist  ");
            }
        }
        #endregion




        #region  Search

        #region  SearchbyCustomer
        /// <summary>
        /// Search for Specific Customer by using SearchKey
        /// parameter (  string )
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Customer created</response>
        /// <response code="400">Customer has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Customer right now</response>

        [HttpGet("Search")]
        public IActionResult Search(string searchkey)
        {
            try
            {
                GeneralResponse<Customer> response = new GeneralResponse<Customer>();

                Customer Customer = _unitOfWork.Customer.Search(k => k.CustomerName == searchkey);
                if (Customer != null)
                {
                    response.Message = "Succes";
                    response.StatusCode = HttpContext.Response.StatusCode;

                    response.Data.Add(Customer);
                    response.Success = true;
                    return Ok(response);
                }
                else
                {
                    response.Message = "Not Found";
                    response.StatusCode = HttpContext.Response.StatusCode = 400;

                    response.Success = false;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                return BadRequest("Please Write the Search Key correctly");
            }
        }


    }
}
#endregion
#endregion
#endregion

    







