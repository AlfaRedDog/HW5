using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class FindItemsResponse : IBaseResponse
    {
        public List<ItemResponse> ItemResponses { get; set; }
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
