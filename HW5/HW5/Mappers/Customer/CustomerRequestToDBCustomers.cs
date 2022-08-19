using HW3.Models.DBTables;
using HW3.Models.Requests;

namespace DataAcess.Mappers.Customer
{
    public class CustomerRequestToDBCustomers
    {
        public DBCustomers Map(CustomerRequest request)
        {
            if (request == null)
                return null;
            DBCustomers result = new()
            {
                Adress = request.Adress,
                Id = request.Id,
                isActive = request.isActive,
                Name = request.Name,
                Surename = request.Surename
            };
            return result;
        }
    }
}
