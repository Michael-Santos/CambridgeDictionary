using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Entry
    {
        /// <summary>
        /// The word class
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// International Phonetic Alphabet, the phonetic transcription of the word's pronunciation
        /// </summary>
        public Ipa Ipa { get; set; }

        /// <summary>
        /// The set of possible meanings of the word
        /// </summary>
        public IEnumerable<Sense> Senses { get; set; }
    }
}
