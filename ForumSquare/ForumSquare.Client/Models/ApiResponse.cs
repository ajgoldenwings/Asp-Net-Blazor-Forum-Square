using System.Net;

namespace ForumSquare.Client.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public ApiError Error { get; set; }
    }
}
