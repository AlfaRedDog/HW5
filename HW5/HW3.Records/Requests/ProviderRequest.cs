using System.Text.Json.Serialization;

namespace HW3.Models.Requests
{
    public class ProviderRequest : DBTables.DBProviders, IUpdateParams
    {
        [JsonIgnore]
        public RequestMode RequestMode;

        public string ValueToUpdate { get; set; }

        public string ColumnToUpdate { get; set; }
    }
}
