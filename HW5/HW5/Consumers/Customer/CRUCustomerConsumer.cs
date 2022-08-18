using DataAcess.Datatables.Repositories.interfaces;
using DataAcess.Mappers;
using HW3.Models.DBTables;
using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAcess.Consumers.Customer
{
    public class CRUCustomerConsumer : IConsumer<CustomerRequest>
    {
        public ICustomerRepository customersRepository { get; set; }
        public DBCustomerToCustomerResponse mapperResponse { get; set; }
        public CustomerRequestToDBCustomers mapperRequest { get; set; }

        public CRUCustomerConsumer(
            [FromServices] ICustomerRepository customersRepository)
        {
            this.customersRepository = customersRepository;
            mapperResponse = new();
            mapperRequest = new();
        }
        public async Task Consume(ConsumeContext<CustomerRequest> context)
        {
            if(context.Message.RequestMode == RequestMode.Create)//работает
            {
                customersRepository.Add(mapperRequest.Map(context.Message));
                await context.RespondAsync<CustomerResponse>(new CustomerResponse() { isSuccess = true });
                return;
            }
            else if(context.Message.RequestMode == RequestMode.Update)
            {
                customersRepository.Update(
                    mapperRequest.Map(context.Message),
                    context.Message.ColumnToUpdate,
                    context.Message.ValueToUpdate);
                await context.RespondAsync<CustomerResponse>(new CustomerResponse() { isSuccess = true, Errors = new List<string>() {""} });
                return;
            }
            else if(context.Message.RequestMode == RequestMode.Read)//работает
            {
                List<DBCustomers> customer = customersRepository.Read(context.Message.Id.ToString(), "Id");
                if (customer.Count == 0)
                {
                    await context.RespondAsync<CustomerResponse>(new CustomerResponse() { isSuccess = false });
                    return;
                }

                CustomerResponse a = mapperResponse.Map(customer[0]);
                a.isSuccess = true;
                a.Errors = new List<string>(){""};
                await context.RespondAsync<CustomerResponse>(a);
                return;
            }

            await context.RespondAsync<CustomerResponse>(new CustomerResponse() { isSuccess = false });
        }
    }
}
