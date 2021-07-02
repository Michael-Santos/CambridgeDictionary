using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class EntrySet
    {
        /// <summary>
        /// Searched word
        /// </summary>
        public string Headword { get; set; }

        /// <summary>
        /// Entries of the word found in the dictionary
        /// </summary>
        public IEnumerable<Entry> Entries { get; set; }

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
