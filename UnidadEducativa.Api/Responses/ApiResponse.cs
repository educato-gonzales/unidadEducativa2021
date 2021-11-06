using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnidadEducativa.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public ApiResponse(T data)
        {
            Data = data;
        }
    }
}
