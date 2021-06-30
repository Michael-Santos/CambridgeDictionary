using System.Collections.Generic;

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
        public string Headline { get; set; }

        /// <summary>
        /// All the possible meanings with examples and guide word whether it's available
        /// </summary>
        public IEnumerable<EntrySet> EntrieSets { get; set; }

        /// <summary>
        /// Similar words sugestion when the searched word wasn't found
        /// </summary>
        public IEnumerable<string> SimilarWords { get; set; }

        /// <summary>
        /// The raw meaning page
        /// </summary>
        public string Raw { get; set; }
    }
}