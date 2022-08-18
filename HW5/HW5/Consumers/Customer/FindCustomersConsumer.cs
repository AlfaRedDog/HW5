﻿using DataAcess.Datatables.Repositories;
using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using DataAcess.Mappers;
using System.Threading.Tasks;
using System;
using DataAcess.Datatables.Repositories.interfaces;

namespace DataAcess.Consumers.Customer
{
    public class FindCustomersConsumer : IConsumer<FindRequest>
    {
        public ICustomerRepository customersRepository { get; set; }
        public ListDBCustomersToFindCustomersResponse mapper { get; set; }
        public FindCustomersConsumer(
            [FromServices] ICustomerRepository customersRepository)
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
