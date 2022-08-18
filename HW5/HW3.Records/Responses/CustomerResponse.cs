using HW3.Models.DBTables;
using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class CustomerResponse : IBaseResponse
    {
        public CustomerResponse()
        {
        }

        public CustomerResponse(DBCustomers customer)
        {
            Name = customer.Name;
            Surename = customer.Surename;
            Adress = customer.Adress;
        }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Adress { get; set; }

        public bool isSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
