using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Models.Responses
{
    public class BaseResponse : IBaseResponse
    {
        public bool isSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
