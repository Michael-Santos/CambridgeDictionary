using HtmlAgilityPack;
using ScrapySharp.Network;

namespace CambridgeDictionary.Cli
{
    public interface IScrapper
    {
        HtmlNode GetPage(string word);
        string GetHeadline(HtmlNode page);
        string GetWord(HtmlNode page);
    }
}
