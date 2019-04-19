using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rex.Temp.BusinessModel.Enum;

namespace Rex.Temp.BusinessModel
{
    public class ApiResult
    {
        public ApiStatusCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class ApiResult<T>
    {
        public ApiStatusCode Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
