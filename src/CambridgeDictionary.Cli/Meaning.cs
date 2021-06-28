namespace CambridgeDictionary.Cli
{
    public class Meaning
    {
        /// <summary>
        /// Searched word
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Usually gets the first meaning available. It's fetched from a meta attribute insted of reading all the page
        /// </summary>
        public string HeadLine { get; set; }

        /// <summary>
        /// The raw meaning page
        /// </summary>
        public string Raw { get; set; }
    }
}