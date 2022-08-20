using HW3.Models.DBTables;
using HW3.Models.Requests;

namespace DataAcess.Mappers.Item
{
    public class ItemRequestToDBItems
    {
        public DBItems Map(ItemRequest request)
        {
            if (request == null)
                return null;
            DBItems result = new()
            {
                Id = request.Id,
                Id_provider = request.Id_provider,
                Amount = request.Amount,
                Price = request.Price,
                Expiration_date = request.Expiration_date,
                isActive = request.isActive
            };
            return result;
        }
    }
}
