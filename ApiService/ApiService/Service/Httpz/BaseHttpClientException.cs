using System.Runtime.Serialization;

namespace ApiService.Service.Httpz
{
    [Serializable]
    public class BaseHttpClientException : Exception
    {
        public BaseHttpClientException()
        {
        }

        public BaseHttpClientException(string? message) : base(message)
        {
        }

        public BaseHttpClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BaseHttpClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}