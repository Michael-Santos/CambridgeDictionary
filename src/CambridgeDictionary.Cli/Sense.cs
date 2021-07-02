using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Sense
    {
        /// <summary>
        /// It's a word that helps you find the right meaning when a word has more than one meaning
        /// </summary>
        public string GuideWord { get; set; }

        /// <summary>
        /// A set of definition of the sense of the word
        /// </summary>
        public IEnumerable<Definition> Definitions { get; set; }
    }
}