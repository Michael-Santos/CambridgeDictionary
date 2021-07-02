using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Sense
    {
        /// <summary>
        /// The word class
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// It's a word that helps you find the right meaning when a word has more than one meaning
        /// </summary>
        public string GuideWord { get; set; }

        /// <summary>
        /// International Phonetic Alphabet, the phonetic transcription of the word's pronunciation
        /// </summary>
        public Ipa Ipa { get; set; }

        /// <summary>
        /// A set of definition of the sense of the word
        /// </summary>
        public IEnumerable<Definition> Definitions { get; set; }
    }
}