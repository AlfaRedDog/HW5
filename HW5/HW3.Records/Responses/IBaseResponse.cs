using System.Collections.Generic;

namespace HW3.Models.Responses
{
    public interface IBaseResponse
    {
        public bool isSuccess { get; set; }

        public List<string> Errors { get; set; }
    }
}
