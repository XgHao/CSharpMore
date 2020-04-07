using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_BlockBuffer_Test
{
    [Serializable]
    public class EnumTransFailedException : ApplicationException
    {
        private string error;
        private Exception innerException;

        public EnumTransFailedException(string message) : base(message)
        {
            error = base.Message;
        }

        public EnumTransFailedException(string message, Exception innerException) : base(message, innerException)
        {
            error = base.Message;
            innerException = base.InnerException;
        }

        public EnumTransFailedException()
        {
        }

        protected EnumTransFailedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            
        }
    }
}
