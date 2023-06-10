namespace KentWebForms.Infrastructure.Models
{
    using System.Net;

    public class Response<T> : Response
    {
        public Response(T data, HttpStatusCode statusCode) : base(statusCode)
        {
            this.Data = data;
        }

        public T Data { get; set; }
    }


    public class Response
    {
        public Response(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; protected set; }
    }
}
