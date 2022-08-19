using HW3.Models.DBTables;
using HW3.Models.Responses;
using System.Collections.Generic;

namespace DataAcess.Mappers.Customer
{
    public class DBCustomerToCustomerResponse
    {
        public CustomerResponse Map(DBCustomers context)
        {
            if (context == null)
                return null;
            var customeResp = new CustomerResponse();
            customeResp.Adress = context.Adress;
            customeResp.Name = context.Name;
            customeResp.Surename = context.Surename;
            customeResp.Errors = null;
            customeResp.isSuccess = true;

            return customeResp;
        }
    }
}
