using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class FindProvidersResponse : IBaseResponse
    {
        public List<ProviderResponse> ProviderResponses { get; set; }
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
