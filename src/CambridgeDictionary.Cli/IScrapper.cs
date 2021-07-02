using HtmlAgilityPack;
using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public interface IScrapper
    {
        HtmlNode GetPage(string word);
        string GetHeadline(HtmlNode page);
        string GetWord(HtmlNode page);
        IEnumerable<EntrySet> GetSenses(HtmlNode page);
        Ipa GetPhonetics(HtmlNode page);
        IEnumerable<string> GetSimilarWords(HtmlNode page);
    }
}
