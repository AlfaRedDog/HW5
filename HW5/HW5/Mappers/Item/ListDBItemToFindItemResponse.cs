using HW3.Models.DBTables;
using HW3.Models.Responses;
using System.Collections.Generic;

namespace DataAcess.Mappers.Item
{
    public class ListDBItemToFindItemResponse
    {
        public FindItemsResponse Map(List<DBItems> context)
        {
            if (context == null)
                return null;
            FindItemsResponse findItemsResponse = new FindItemsResponse() { ItemResponses = new List<ItemResponse>(), Errors = new List<string>(), isSuccess = true };
            DBItemToItemResponse mapper = new();

            foreach (var item in context)
            {
                findItemsResponse.ItemResponses.Add(mapper.Map(item));
            }

            return findItemsResponse;
        }
    }
}
