using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Phonetics
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
