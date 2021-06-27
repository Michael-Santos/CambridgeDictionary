namespace CambridgeDictionary.Cli.Exceptions
{
    public class NotFound : CambridgeDictionaryException
    {
        public NotFound()
        {
            Message = "Word not found. Try find similar words!";
            Details = "";
        }
    }
}
