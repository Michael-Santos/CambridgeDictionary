using System;
using System.Runtime.Serialization;

namespace CambridgeDictionary.Cli.Exceptions
{
    public class CambridgeDictionaryException : Exception
    {
        public CambridgeDictionaryException()
        {
        }

        public CambridgeDictionaryException(string message) : base(message)
        {
        }

        public CambridgeDictionaryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
