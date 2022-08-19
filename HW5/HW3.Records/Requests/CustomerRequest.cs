using System.Text.Json.Serialization;

namespace HW3.Models.Requests
{
    public class CustomerRequest : DBTables.DBCustomers, IUpdateParams
    {
        [JsonIgnore]
        public RequestMode RequestMode;

        public string ValueToUpdate { get; set; }

        public string ColumnToUpdate { get; set; }
    }
}
