using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Models.Requests
{
    public interface IUpdateParams
    {
        public string ValueToUpdate { get; set; }

        public string ColumnToUpdate { get; set; }
    }
}
