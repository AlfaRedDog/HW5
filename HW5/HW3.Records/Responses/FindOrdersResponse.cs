using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class FindOrdersResponse : IBaseResponse
    {
        public List<OrderResponse> OrderResponses { get; set; }
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
