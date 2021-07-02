using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Entry
    {
        /// <summary>
        /// The meaning itself
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Examples of sentences using the searched word
        /// </summary>
        public IEnumerable<string> Examples { get; set;  }


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
