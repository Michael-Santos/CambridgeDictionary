using HtmlAgilityPack;
using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public interface IScrapper
    {
        HtmlNode GetPage(string word);
        string GetHeadline(HtmlNode page);
        string GetWord(HtmlNode page);

        void GetEntries(HtmlNode page);
        void GetPhonetics(HtmlNode page);
        IEnumerable<string> GetSimilarWords(HtmlNode page);
    }
}
