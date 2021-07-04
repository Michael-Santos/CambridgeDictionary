using System.Collections.Generic;

namespace CambridgeDictionary.Cli.Debug
{
    public interface IRunner
    {
        EntrySet Run(string word, bool useCache = true);
        List<EntrySet> RunRange(params string[] words);
    }
}
