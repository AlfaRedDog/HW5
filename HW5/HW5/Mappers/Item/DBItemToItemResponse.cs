using HW3.Models.DBTables;
using HW3.Models.Responses;

namespace DataAcess.Mappers.Item
{
    public class DBItemToItemResponse
    {
        public ItemResponse Map(DBItems context)
        {
            if (context == null)
                return null;
            var itemResp = new ItemResponse();
            itemResp.Amount = context.Amount;
            itemResp.Price = context.Price;
            itemResp.Expiration_date = context.Expiration_date;
            itemResp.Errors = null;
            itemResp.isSuccess = true;

            return itemResp;
        }
    }
}
