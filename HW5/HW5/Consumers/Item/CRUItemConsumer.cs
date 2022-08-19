using DataAcess.Datatables.Repositories.interfaces;
using DataAcess.Mappers.Item;
using HW3.Models.DBTables;
using HW3.Models.Requests;
using HW3.Models.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAcess.Consumers.Item
{
    public class CRUItemConsumer : IConsumer<ItemRequest>
    {
        public IItemsRepository ItemsRepository { get; set; }
        public DBItemToItemResponse mapperResponse { get; set; }
        public ItemRequestToDBItems mapperRequest { get; set; }

        public CRUItemConsumer(
            [FromServices] IItemsRepository ItemsRepository)
        {
            this.ItemsRepository = ItemsRepository;
            mapperResponse = new();
            mapperRequest = new();
        }
        public async Task Consume(ConsumeContext<ItemRequest> context)
        {
            if (context.Message.RequestMode == RequestMode.Create)
            {
                ItemsRepository.Add(mapperRequest.Map(context.Message));
                await context.RespondAsync<ItemResponse>(new ItemResponse() { isSuccess = true });
                return;
            }
            else if (context.Message.RequestMode == RequestMode.Update)
            {
                ItemsRepository.Update(
                    mapperRequest.Map(context.Message),
                    context.Message.ValueToUpdate,
                    context.Message.ColumnToUpdate);
                await context.RespondAsync<ItemResponse>(new ItemResponse() { isSuccess = true, Errors = new List<string>() { "" } });
                return;
            }
            else if (context.Message.RequestMode == RequestMode.Read)
            {
                List<DBItems> Item = ItemsRepository.Read(context.Message.Id.ToString(), "Id");
                if (Item.Count == 0)
                {
                    await context.RespondAsync<ItemResponse>(new ItemResponse() { isSuccess = false });
                    return;
                }

                ItemResponse a = mapperResponse.Map(Item[0]);
                a.isSuccess = true;
                a.Errors = new List<string>() { "" };
                await context.RespondAsync<ItemResponse>(a);
                return;
            }

            await context.RespondAsync<ItemResponse>(new ItemResponse() { isSuccess = false });
        }
    }
}
