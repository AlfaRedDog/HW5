using DataAcess.Datatables.Repositories;
using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DataAcess.Datatables.Repositories.interfaces;
using DataAcess.Mappers.Item;

namespace DataAcess.Consumers.Item
{
    public class FindItemsConsumer : IConsumer<FindRequest>
    {
        public IItemsRepository ItemsRepository { get; set; }
        public ListDBItemToFindItemResponse mapper { get; set; }
        public FindItemsConsumer(
            [FromServices] IItemsRepository ItemsRepository)
        {
            this.ItemsRepository = ItemsRepository;
            this.mapper = new();
        }

        public async Task Consume(ConsumeContext<FindRequest> context)
        {
            await context.RespondAsync<FindItemsResponse>(mapper.Map(ItemsRepository.Read(context.Message.Value, context.Message.Column)));
        }
    }
}
