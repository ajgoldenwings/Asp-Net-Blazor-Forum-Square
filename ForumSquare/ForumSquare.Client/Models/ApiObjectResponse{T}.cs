using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumSquare.Client.Models
{
    public class ApiObjectResponse<T> : ApiResponse
    {
        public T Response { get; set; }
    }
}
