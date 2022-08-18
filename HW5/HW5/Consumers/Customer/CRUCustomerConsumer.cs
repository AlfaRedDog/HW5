using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace DataAcess.Consumers.Customer
{
    public class CRUCustomerConsumer : IConsumer<CustomerRequest>
    {
        public async Task Consume(ConsumeContext<CustomerRequest> context)
        {
  
            await context.RespondAsync<CustomerResponse>(new CustomerResponse() { isSuccess = true });
        }
    }
}
