using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class Entry
    {
        public string Type { get; set; }
        public string Definition { get; set; }
        public IEnumerable<string> Examples { get; set;  }
    }
}
