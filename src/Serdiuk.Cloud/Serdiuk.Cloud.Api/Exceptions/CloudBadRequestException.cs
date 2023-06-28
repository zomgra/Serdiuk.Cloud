namespace Serdiuk.Cloud.Api.Exceptions
{
    public class CloudBadRequestException : Exception
    {
        public CloudBadRequestException() : base()
        {

        }
        public CloudBadRequestException(string messages) : base(messages)
        {

        }
        public CloudBadRequestException(string message,Exception e) : base(message, e)
        {

        }
    }
}
