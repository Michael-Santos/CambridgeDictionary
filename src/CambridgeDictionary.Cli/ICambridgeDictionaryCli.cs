using System.Collections.Generic;

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
    }
}
