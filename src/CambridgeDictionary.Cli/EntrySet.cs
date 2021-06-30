﻿using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class EntrySet
    {
        /// <summary>
        /// It's a word that helps you find the right meaning when a word has more than one meaning
        /// </summary>
        public string GuideWord { get; set; }

        public IEnumerable<Entry> Entries { get; set; }
    }
}
