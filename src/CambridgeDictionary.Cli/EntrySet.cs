using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class EntrySet
    {
        public string GuideWord { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
    }
}
