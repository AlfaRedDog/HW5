using DataAcess.Datatables.Repositories;
using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DataAcess.Datatables.Repositories.interfaces;
using DataAcess.Mappers.Customer;

namespace DataAcess.Consumers.Customer
{
    public class FindCustomersConsumer : IConsumer<FindRequest>
    {
        public ICustomersRepository customersRepository { get; set; }
        public ListDBCustomersToFindCustomersResponse mapper { get; set; }
        public FindCustomersConsumer(
            [FromServices] ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
            this.mapper = new();
        }

        public async Task Consume(ConsumeContext<FindRequest> context)
        {
            await context.RespondAsync<FindCustomersResponse>(mapper.Map(customersRepository.Read(context.Message.Value, context.Message.Column)));
        }
    }
}
