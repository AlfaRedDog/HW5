using DataAcess.Datatables.Repositories;
using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DataAcess.Datatables.Repositories.interfaces;
using DataAcess.Mappers.Item;
using DataAcess.Mappers.Customer;

namespace DataAcess.Consumers
{
    public class FindConsumer : IConsumer<FindRequest>
    {
        public IItemsRepository ItemsRepository { get; set; }
        public ListDBItemToFindItemResponse mapperItems { get; set; }
        public ICustomersRepository customersRepository { get; set; }
        public ListDBCustomersToFindCustomersResponse mapperCustomers { get; set; }
        public FindConsumer(
            [FromServices] IItemsRepository ItemsRepository,
            [FromServices] ICustomersRepository customersRepository)
        {
            this.ItemsRepository = ItemsRepository;
            this.customersRepository = customersRepository;
            mapperCustomers = new();
            mapperItems = new();
        }

        public async Task Consume(ConsumeContext<FindRequest> context)
        {
            if (context.Message.TableName == TablesEnum.Items)
            {
                await context.RespondAsync(mapperItems.Map(ItemsRepository.Read(context.Message.Value, context.Message.Column)));
            }
            if(context.Message.TableName == TablesEnum.Customers)
            {
                await context.RespondAsync<FindCustomersResponse>(mapperCustomers.Map(customersRepository.Read(context.Message.Value, context.Message.Column)));
            }
        }
    }
}
