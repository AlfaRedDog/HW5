using System.Text.Json.Serialization;

namespace HW3.Models.Requests
{
    public class ProviderRequest : DBTables.DBProviders
    {
        [JsonIgnore]
        public RequestMode RequestMode;
    }
}
