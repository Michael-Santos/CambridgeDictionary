using System;

namespace CambridgeDictionary.Cli.Exceptions
{
    /// <summary>
    /// It's thrown when it wasn't possible to reach the Cambridge site
    /// </summary>
    public class ServiceUnreachableException : CambridgeDictionaryException
    {
        public ServiceUnreachableException()
        {
        }

        public ServiceUnreachableException(string message) : base(message)
        {
        }

        public ServiceUnreachableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
