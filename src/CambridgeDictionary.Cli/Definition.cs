using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    /// <summary>
    /// Represents a definition of the sense
    /// </summary>
    public  class Definition
    {
        /// <summary>
        /// The definition itself
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Examples of use of the word in the specific definition
        /// </summary>
        public IEnumerable<string> Examples { get; set; }
    }
}