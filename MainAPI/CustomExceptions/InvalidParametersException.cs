
namespace MainAPI.CustomExceptions
{
    public class InvalidParametersException : BaseCustomException
    {
        public InvalidParametersException() : base() { }

        public InvalidParametersException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}