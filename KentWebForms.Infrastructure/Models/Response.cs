namespace KentWebForms.Infrastructure.Models
{
    using System.Net;

    public class Response<T> : Response
    {
        public Response(T data, int statusCode) : base(statusCode)
        {
            this.Data = data;
        }

        public Response()
        {
        }

        public T Data { get; set; }
    }


    public class Response
    {
        public Response(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public Response()
        {
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public void SetSuccess()
        {
            this.StatusCode = (int)HttpStatusCode.OK;
        }

        public void SetFail(string message)
        {
            this.StatusCode = (int)HttpStatusCode.InternalServerError;
            this.Message = message;
        }
    }
}
