using System;
using System.Runtime.Serialization;

namespace Wj.Bizlogic
{
    public class AppException : Exception
    {
        public AppException()
        {

        }

        public AppException(string? message)
            : base(message)
        {

        }

        public AppException(string? message, Exception? innerException)
            : base(message, innerException)
        {

        }

        public AppException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {

        }
    }
}

