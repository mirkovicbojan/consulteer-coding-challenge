using System.Net;

namespace MainAPI.CustomExceptions
{
    public class BaseCustomException : Exception
    {
        public HttpStatusCode StatusCode;

        public BaseCustomException() { }

        public BaseCustomException(string message) : base(message) { }
    }
}