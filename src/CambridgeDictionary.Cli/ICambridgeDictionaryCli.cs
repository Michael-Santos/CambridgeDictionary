﻿using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public interface ICambridgeDictionaryCli
    {
        /// <summary>
        /// Search for entries of the word in dictionary
        /// </summary>
        /// <param name="word">The word to be searched.</param>
        /// <returns>The information about the word on the dictionary</returns>
        EntrySet GetEntry(string word);

        /// <summary>
        /// Fetch the entries of the word in dictionary directly from a html source
        /// </summary>
        /// <param name="htmlSource">The html source</param>
        /// <returns>The information about the word on the dictionary</returns>
        EntrySet GetEntryFromHtmlSource(string htmlSource);
    }
}
