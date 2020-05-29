using System;
using System.Runtime.Serialization;

namespace CIPSA.Util.ConsoleApp.CustomException
{
    public class TePasasteException : Exception
    {
        #region Ctors.
        public TePasasteException()
        {
        }

        public TePasasteException(string message) : base(message)
        {
        }

        public TePasasteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TePasasteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
