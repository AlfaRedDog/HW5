using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HW3.Models.Requests
{
    public class FindRequest
    { 
        [JsonIgnore]
        public TablesEnum TableName { get; set; }

        public string Column { get; set; }

        public string Value { get; set; }
    }
}
