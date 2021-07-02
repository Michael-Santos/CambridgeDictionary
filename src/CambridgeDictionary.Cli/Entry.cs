﻿using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Entry
    {
        /// <summary>
        /// The word class
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The meaning itself
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Examples of sentences using the searched word
        /// </summary>
        public IEnumerable<string> Examples { get; set;  }




        /// <summary>
        /// Searched word
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// The set of possible meanings of the word
        /// </summary>
        public IEnumerable<Sense> Senses { get; set; }

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
