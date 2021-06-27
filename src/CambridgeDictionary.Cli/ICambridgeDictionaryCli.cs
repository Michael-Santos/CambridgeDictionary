using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public interface ICambridgeDictionaryCli
    {
        Meaning GetMeaning(string word);
        IEnumerable<string> GetSimilarWords(string word);
    }
}
