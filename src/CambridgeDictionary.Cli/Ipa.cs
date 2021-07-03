using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    /// <summary>
    /// Represents the International Phonetic Alphabet, the phonetic transcription of the word's pronunciation
    /// </summary>
    public class Ipa
    {
        /// <summary>
        /// UK pronounces
        /// </summary>
        public IEnumerable<string> UK { get; set; }

        /// <summary>
        /// US pronounces
        /// </summary>
        public IEnumerable<string> US { get; set; }
    }
}
