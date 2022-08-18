using System.Text.Json.Serialization;

namespace HW3.Models.Requests
{
    public class ItemRequest : DBTables.DBItems
    {
        [JsonIgnore]
        public RequestMode RequestMode;
    }
}
