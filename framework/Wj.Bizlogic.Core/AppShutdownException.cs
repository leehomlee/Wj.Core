using System;
using System.Runtime.Serialization;

namespace Wj.Bizlogic
{
    public class AppShutdownException : Exception
    {
        public AppShutdownException()
        {

        }

        public AppShutdownException(string message)
            : base(message)
        {

        }

        public AppShutdownException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public AppShutdownException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { 
            
        }
    }
}

