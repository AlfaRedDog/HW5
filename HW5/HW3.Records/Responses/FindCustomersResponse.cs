using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class FindCustomersResponse : IBaseResponse
    {
        public List<CustomerResponse> customerResponses { get; set; }
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
