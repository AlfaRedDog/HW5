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
                return new BaseResponse()
                {
                    Errors = new List<string>() {"column or value is empty "},
                    isSuccess = false
                };
            }
            FindRequest findRequest = new FindRequest() { 
                                                        RequestMode = RequestMode.Find, 
                                                        Column = column, 
                                                        Value = value };
            var response = await requestClient.GetResponse<FindCustomersResponse>(findRequest);

            return response.Message;
        }

        [HttpGet("ReadCustomer")]
        public async Task<IBaseResponse> ReadAsync(
            [FromServices] IRequestClient<CustomerRequest> requestClient,
            [FromBody] CustomerRequest customer)
        {
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                return new BaseResponse()
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                    isSuccess = false
                };
            }
            customer.RequestMode = RequestMode.Read;
            var response = await requestClient.GetResponse<CustomerResponse>(customer);

            return response.Message;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IBaseResponse> CreateAsync(
            [FromServices] IRequestClient<CustomerRequest> requestClient,
            [FromBody] CustomerRequest customer)
        {
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                return new BaseResponse()
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                    isSuccess = false
                };
            }
            customer.RequestMode = RequestMode.Create;
            var response = await requestClient.GetResponse<CustomerResponse>(customer);

            return response.Message;
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IBaseResponse> UpdateAsync(
            [FromServices] IRequestClient<CustomerRequest> requestClient,
            [FromBody] CustomerRequest customer)
        {
            FluentValidation.Results.ValidationResult validationResult = validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                return new BaseResponse()
                {
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
                    isSuccess = false
                };
            }

            customer.RequestMode = RequestMode.Update;
            var response = await requestClient.GetResponse<CustomerResponse>(customer);

            return response.Message;
        }
    }
}
