using HW3.Models.DBTables;
using System;
using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class ItemResponse : IBaseResponse
    {
        public ItemResponse()
        {
        }

        public ItemResponse(DBItems items)
        {
            Amount = items.Amount;
            Price = items.Price;
            Expiration_date = items.Expiration_date;
        }

        public int Amount { get; set; }

        public int Price { get; set; }

        public DateTime Expiration_date { get; set; }

        public bool isSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
