using HW3.Models.DBTables;
using HW3.Models.Responses;
using System.Collections.Generic;

namespace DataAcess.Mappers.Customer
{
    public class ListDBCustomersToFindCustomersResponse
    {
        public FindCustomersResponse Map(List<DBCustomers> context)
        {
            if (context == null)
                return new FindCustomersResponse();
            FindCustomersResponse findCustomersResponse = new FindCustomersResponse() { customerResponses = new List<CustomerResponse>(), Errors = new List<string>(), isSuccess = true };
            DBCustomerToCustomerResponse mapper = new();

            foreach (var item in context)
            {
                findCustomersResponse.customerResponses.Add(mapper.Map(item));
            }

            return findCustomersResponse;
        }
    }
}
