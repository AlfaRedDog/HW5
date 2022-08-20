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
    public class ItemController : ControllerBase
    {
        ItemRequestValidator validator = new ItemRequestValidator();

        [HttpGet("FindItems")]
        public async Task<IBaseResponse> FindAsync(
            [FromServices] IRequestClient<FindRequest> requestClient,
            [FromQuery] string column,
            [FromQuery] string value)
        {
            if (column is null || value is null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new BaseResponse()
                {
                    Errors = new List<string>() { "column or value is empty " },
                    isSuccess = false
                };
            }
            FindRequest findRequest = new FindRequest()
            {
                TableName = TablesEnum.Items,
                Column = column,
                Value = value
            };

            try
            {
                var response = await requestClient.GetResponse<FindItemsResponse>(findRequest);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return response.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpGet("ReadItem")]
        public async Task<IBaseResponse> ReadAsync(
            [FromServices] IRequestClient<ItemRequest> requestClient,
            [FromBody] ItemRequest item)
        {
            try
            {
                item.RequestMode = RequestMode.Read;
                var response = await requestClient.GetResponse<ItemResponse>(item);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return response.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpPost("CreateItem")]
        public async Task<IBaseResponse> CreateAsync(
            [FromServices] IRequestClient<ItemRequest> requestClient,
            [FromBody] ItemRequest item)
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(item);

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
                item.RequestMode = RequestMode.Create;
                var response = await requestClient.GetResponse<ItemResponse>(item);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
                return response.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }

        [HttpPut("UpdateItem")]
        public async Task<IBaseResponse> UpdateAsync(
            [FromServices] IRequestClient<ItemRequest> requestClient,
            [FromBody] ItemRequest item)
        {
            FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(item);

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
                item.RequestMode = RequestMode.Update;
                var response = await requestClient.GetResponse<ItemResponse>(item);

                return response.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
        }
    }
}