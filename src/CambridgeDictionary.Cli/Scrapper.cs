using HtmlAgilityPack;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<EntrySet> GetEntries(HtmlNode page)
        {
            var nodes = page.SelectNodes("//div[@class='pr dictionary']");

            if (nodes.Count == 0)
            {
                return null;
            }

            var hasMultiplesMeanings = HasMultiplesDefinitions(nodes[0]);
            
            var entrySet = new List<EntrySet>();
            foreach (var node in nodes)
            {
                if (hasMultiplesMeanings)
                {
                    throw new NotImplementedException();
                }

                var definition = ExtractSingleDefinitionNode(node);
                entrySet.Add(definition);
            }

            return entrySet;
        }

        private static bool HasMultiplesDefinitions(HtmlNode page)
        {
            return page.SelectSingleNode("//div[@class='entry']") != null;
        }

        private EntrySet ExtractSingleDefinitionNode(HtmlNode page)
        {
            var entry = new Entry();
            
            var idiomBlockNode = page.SelectSingleNode("//div[@class='def ddef_d db']");
            entry.Definition = idiomBlockNode.InnerText;
            entry.Examples = page.SelectNodes("//div[@class='examp dexamp']").Select(x => x.InnerText);

            var entrySet = new EntrySet();
            entrySet.Entries = new List<Entry>();
            entrySet.Entries.Append(entry);

            return entrySet;
        }

        public IEnumerable<string> GetSimilarWords(HtmlNode page)
        {
            var node = page.SelectSingleNode("//p[contains(text(), 'We have these words')]");

            if (node == null)
            {
                return null;
            }

            throw new NotImplementedException();
        }

        public void GetPhonetics(HtmlNode page)
        {
            throw new NotImplementedException();
        }
    }
}
