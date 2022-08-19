using HW3.Models.DBTables;
using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public class ProviderResponse : IBaseResponse
    {
        public ProviderResponse(DBProviders provider)
        {
            Name = provider.Name;
            Adress = provider.Adress;
        }

        public string Name { get; set; }

        public string Adress { get; set; }

        public bool isSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
