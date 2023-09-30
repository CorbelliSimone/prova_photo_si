using System.Runtime.Serialization;

namespace ApiService.Service.AddressBook.Exceptionz
{
    [Serializable]
    public class AddressBookException : Exception
    {
        public AddressBookException()
        {
        }

        public AddressBookException(string? message) : base(message)
        {
        }

        public AddressBookException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AddressBookException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}