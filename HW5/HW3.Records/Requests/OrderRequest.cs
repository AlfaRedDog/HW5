using System.Text.Json.Serialization;

namespace HW3.Models.Requests
{
    public class OrderRequest : DBTables.DBOrders
    {
        [JsonIgnore]
        public RequestMode RequestMode;
    }
}
