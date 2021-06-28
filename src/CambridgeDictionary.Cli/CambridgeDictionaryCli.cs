using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CambridgeDictionary.Cli
{
    public class CambridgeDictionaryCli : ICambridgeDictionaryCli
    {
        const string urlBase = "https://dictionary.cambridge.org/search/direct/?datasetsearch=english&q=";

        public Meaning GetMeaning(string word)
        {
            var url = urlBase + HttpUtility.UrlEncode(word);

            var browser = new ScrapingBrowser();
            browser.Encoding = Encoding.UTF8;

            var homePage = browser.NavigateToPage(new Uri(url));

            var html = homePage.Html;
            var headlineNode = html.SelectSingleNode("//meta[@itemprop='headline']");

            var headline = headlineNode.GetAttributeValue("content", "");

            return  new Meaning
            {
                Word = word,
                HeadLine = headline,
                Raw = homePage.RawResponse.ToString()
            };
        }

        public IEnumerable<string> GetSimilarWords(string word)
        {
            throw new NotImplementedException();
        }
    }
}
