using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Web;

namespace CambridgeDictionary.Cli
{
    public class Scrapper : IScrapper
    {
        const string _urlBase = "https://dictionary.cambridge.org/search/direct/?datasetsearch=english&q=";
        private readonly ScrapingBrowser _browser;

        public Scrapper(ScrapingBrowser browser)
        {
            _browser = browser;
        }

        public HtmlNode GetPage(string word)
        {
            var url = _urlBase + HttpUtility.UrlEncode(word);
            return _browser.NavigateToPage(new Uri(url)).Html;
        }

        public string GetHeadline(HtmlNode page)
        {
            var node = page.SelectSingleNode("//meta[@itemprop='headline']");
            var contentAttributeValue = node.GetAttributeValue("content", "");
            return HttpUtility.HtmlDecode(contentAttributeValue);
        }

        public string GetWord(HtmlNode page)
        {
            var node = page.SelectSingleNode("//div[@class='di-title']/span");

            if (node == null)
            {
                node = page.SelectSingleNode("//div[@class='di-title']/h2/b");
            }

            return node.InnerHtml;
        }
    }
}
