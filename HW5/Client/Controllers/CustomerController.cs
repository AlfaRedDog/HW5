using Microsoft.AspNetCore.Mvc;
using HW3.Models.Requests;
using HW3.Models.Responses;
using System.Collections.Generic;
using Client.Validations.Interfaces;
using Client.Validations;
using System;
using System.Linq;
using MassTransit;
using System.Threading.Tasks;
using System.Net;

namespace DataAcess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        CustomerRequestValidator validator = new CustomerRequestValidator();

        [HttpGet("FindCustomers")]
        public async Task<IBaseResponse> FindAsync(
            [FromServices] IRequestClient<FindRequest> requestClient,
            [FromQuery] string column,
            [FromQuery] string value)
        {
            if(column is null || value is null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BaseResponse()
                {
                    Errors = new List<string>() {"column or value is empty "},
                    isSuccess = false
                };
            }
            FindRequest findRequest = new FindRequest() { 
                                                        TableName = TablesEnum.Customers, 
                                                        Column = column, 
                                                        Value = value };

            try
            {
                var response = await requestClient.GetResponse<FindCustomersResponse>(findRequest);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return response.Message;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpGet("ReadCustomer")]
        public async Task<IBaseResponse> ReadAsync(
            [FromServices] IRequestClient<CustomerRequest> requestClient,
            [FromBody] CustomerRequest customer)
        {
            try
            {
                customer.RequestMode = RequestMode.Read;
                var response = await requestClient.GetResponse<CustomerResponse>(customer);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return response.Message;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpPost("CreateCustomer")]
        public async Task<IBaseResponse> CreateAsync(
            [FromServices] IRequestClient<CustomerRequest> requestClient,
            [FromBody] CustomerRequest customer)
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BaseResponse()
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                    isSuccess = false
                };
            }

            try
            {
                customer.RequestMode = RequestMode.Create;
                var response = await requestClient.GetResponse<CustomerResponse>(customer);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
                return response.Message;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IBaseResponse> UpdateAsync(
            [FromServices] IRequestClient<CustomerRequest> requestClient,
            [FromBody] CustomerRequest customer)
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BaseResponse()
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                    isSuccess = false
                };
            }

            try
            {
                customer.RequestMode = RequestMode.Update;
                var response = await requestClient.GetResponse<CustomerResponse>(customer);

                return response.Message;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }
    }
}
