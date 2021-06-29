using HtmlAgilityPack;
using ScrapySharp.Network;

namespace CambridgeDictionary.Cli
{
    public interface IScrapper
    {
        HtmlNode GetPage(string word);
        string GetWord(HtmlNode page);
        string GetHeadline(HtmlNode page);
    }
}
