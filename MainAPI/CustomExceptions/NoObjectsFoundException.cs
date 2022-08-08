
namespace MainAPI.CustomExceptions
{
    public class NoObjectsFoundException : BaseCustomException
    {
        public NoObjectsFoundException() : base() { }

        public NoObjectsFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}