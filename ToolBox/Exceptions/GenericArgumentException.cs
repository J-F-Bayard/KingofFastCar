using System;
using System.Runtime.Serialization;

namespace ToolBox.Exceptions
{
    [Serializable]
    internal class GenericArgumentException : Exception
    {
        public GenericArgumentException()
        {
        }

        public GenericArgumentException(string message) : base(message)
        {
        }

        public GenericArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GenericArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}