using HW3.Models.DBTables;
using HW3.Models.Responses;
using System.Collections.Generic;

namespace DataAcess.Mappers
{
    public class ListDBCustomersToFindCustomersResponse
    {
        public FindCustomersResponse Map(List<DBCustomers> context)
        {
            List<CustomerResponse> map = new List<CustomerResponse>();
            CustomerResponse customeResp = new CustomerResponse();

            foreach(var item in context)
            {
                customeResp.Adress = item.Adress;
                customeResp.Name = item.Name;
                customeResp.Surename = item.Surename;
                customeResp.Errors = null;
                customeResp.isSuccess = true;
                map.Add(customeResp);
            }
            FindCustomersResponse findCustomersResponse = new FindCustomersResponse();
            findCustomersResponse.customerResponses = map;
            return findCustomersResponse;
        }
    }
}
