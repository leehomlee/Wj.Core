using System;
using System.Runtime.Serialization;

namespace Wj.Bizlogic
{
    public class AppInitializationException : Exception
    {
        public AppInitializationException()
        {

        }

        public AppInitializationException(string message)
            : base(message)
        {

        }

        public AppInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public AppInitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        { 
            
        }
    }
}

