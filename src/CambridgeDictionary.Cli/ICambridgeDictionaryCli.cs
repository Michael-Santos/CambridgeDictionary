using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public interface ICambridgeDictionaryCli
    {
        /// <summary>
        /// Search for the meaning and other information of the word on the dictionary
        /// </summary>
        /// <param name="word">It's the word to be searched.</param>
        /// <returns>The information about the word on the dictionary</returns>
        Meaning GetMeaning(string word);
        IEnumerable<string> GetSimilarWords(string word);
    }
}
