using Common.Modules.Base.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Agrostore.ProductsManagement.Interface.Exceptions
{
    public class InvalidProductException : ModuleException
    {
        public InvalidProductException(string message, string module) : base(message, module)
        {
        }

        public InvalidProductException(string message, Exception innerException, string module) : base(message, innerException, module)
        {
        }

        protected InvalidProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
