using HW3.Models.DBTables;
using HW3.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataAcess.Mappers
{
    public class ListDBCustomersToFindCustomersResponse
    {
        public FindCustomersResponse Map(List<DBCustomers> context)
        {
            if (context == null)
                return null;
            FindCustomersResponse findCustomersResponse = new FindCustomersResponse();
            DBCustomerToCustomerResponse mapper = new();

            foreach(var item in context)
            {
                findCustomersResponse.customerResponses.Add(mapper.Map(item));
            }

            return findCustomersResponse;
        }
    }
}
