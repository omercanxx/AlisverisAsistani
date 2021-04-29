using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException()
            : base()
        { }

        public CustomException(String message)
            : base(message)

        { }

        public CustomException(String message, Exception innerException)
            : base(message, innerException)
        { }

        protected CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
