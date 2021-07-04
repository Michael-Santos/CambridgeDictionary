using System;

namespace CambridgeDictionary.Cli.Exceptions
{
    public class ServiceUnreachable : CambridgeDictionaryException
    {
        public ServiceUnreachable()
        {
        }

        public ServiceUnreachable(string message) : base(message)
        {
        }

        public ServiceUnreachable(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
