using Common.Modules.Base.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Agrostore.CategoriesManagement.Interface.Exceptions
{
    public class InvalidCategoryException : ModuleException
    {
        public InvalidCategoryException(string message, string module) : base(message, module)
        {
        }

        public InvalidCategoryException(string message, Exception innerException, string module) : base(message, innerException, module)
        {
        }

        protected InvalidCategoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
