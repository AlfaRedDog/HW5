using HW3.Models.DBTables;
using System;
using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class OrderResponse : IBaseResponse
    {
        public OrderResponse(DBOrders order)
        {
            Id = order.Id;
            Id_item = order.Id_item;
            Amount = order.Amount;
        }

        public Guid Id { get; set; }

        public Guid Id_item { get; set; }

        public int Amount { get; set; }

        public bool isSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
