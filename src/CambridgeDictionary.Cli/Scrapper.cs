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

            return node.InnerText;
        }

        public IEnumerable<EntrySet> GetEntries(HtmlNode page)
        {
            var nodes = page.SelectNodes("//div[@class='pr dictionary']");

            if (nodes == null)
            {
                return null;
            }

            var hasMultiplesMeanings = HasMultiplesDefinitions(nodes[0]);
            
            var entrySet = new List<EntrySet>();
            foreach (var node in nodes)
            {
                if (hasMultiplesMeanings)
                {
                    entrySet.AddRange(ExtractMultiplesDefinitionsNode(node));
                }
                else
                {
                    entrySet.Add(ExtractSingleDefinitionNode(node));
                }
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
            
            var definitionNode = page.SelectSingleNode("//div[@class='def ddef_d db']");
            entry.Definition = definitionNode.InnerText;
            entry.Examples = page.SelectNodes("//div[@class='examp dexamp']").Select(x => x.InnerText);

            var entrySet = new EntrySet();
            entrySet.Entries = new List<Entry>();
            entrySet.Entries = entrySet.Entries.Append(entry);

            return entrySet;
        }

        private IEnumerable<EntrySet> ExtractMultiplesDefinitionsNode(HtmlNode page)
        {
            var entrySetList = new List<EntrySet>();
            
            var entryBodyNodeElementNodes = page.Descendants().Where(x => x.HasClass("entry-body__el"));
            
            foreach (var entryBodyNodeElementNode in entryBodyNodeElementNodes)
            {
                var type = ExtractType(entryBodyNodeElementNode);

                var dsenseNodes = entryBodyNodeElementNode.Descendants().Where(x => x.HasClass("dsense"));
                foreach (var dsense in dsenseNodes)
                {
                    var guideWord = ExtractGuideWord(dsense);
                    var entries = ExtractEntries(dsense, type);

                    var entrySet = new EntrySet
                    {
                        GuideWord = guideWord,
                        Entries = entries
                    };

                    entrySetList.Add(entrySet);
                }
            }

            return entrySetList;
        }

        private string ExtractType(HtmlNode node)
        {
            var typeNode = node.Descendants()
                    .Where(x => x.HasClass("pos") && x.HasClass("dpos"))
                    .First();

            return typeNode.InnerText;
        }

        private string ExtractGuideWord(HtmlNode node)
        {
            var guideWordNode = node.Descendants()
                    .Where(x => x.HasClass("guideword"))
                    .FirstOrDefault();

            return guideWordNode?.InnerText;
        }

        private IEnumerable<Entry> ExtractEntries(HtmlNode node, string type)
        {
            var entryNodes = node.Descendants()
                .Where(x => x.HasClass("def-block"));

            var entries = new List<Entry>();
            foreach (var entryNode in entryNodes)
            {
                var definition = ExtractDefinition(entryNode);
                var examples = ExtractExamples(entryNode);

                var entry = new Entry
                {
                    Type = type,
                    Definition = definition,
                    Examples = examples
                };
                
                entries.Add(entry);
            }

            return entries;
        }

        private string ExtractDefinition(HtmlNode node)
        {
            var definitionNode = node.Descendants()
                    .Where(x => x.HasClass("def") && x.HasClass("ddef_d"))
                    .First();

            return definitionNode.InnerText;
        }

        private IEnumerable<string> ExtractExamples(HtmlNode node)
        {
            var examplesNodes = node.Descendants()
                .Where(x => x.HasClass("examp"));

            return examplesNodes.Select(x => x.InnerText);
        }

        public IEnumerable<string> GetSimilarWords(HtmlNode page)
        {
            var node = page.Descendants("p")
                .Where(x => x.InnerText.Contains("We have these words"))
                .FirstOrDefault();

            if (node == null)
            {
                return null;
            }

            var similarWordsNodes = node.NextSibling.NextSibling.Descendants("span");
            return similarWordsNodes.Select(x => x.FirstChild.InnerHtml);
        }

        public Phonetics GetPhonetics(HtmlNode page)
        {
            var ukPhonetics = ExtractPhonetics(page, "uk");
            var usPhonetics = ExtractPhonetics(page, "us");

            if (ukPhonetics == null && usPhonetics == null)
            {
                return null;
            }

            return new Phonetics
            {
                UK = ukPhonetics,
                US = usPhonetics
            };
        }

        private IEnumerable<string> ExtractPhonetics(HtmlNode page, string region)
        {
            var phoneticDpronNodes = page.Descendants("span").Where(x => x.HasClass(region) && x.HasClass("dpron-i"));

            return phoneticDpronNodes.Select(
                x => x.Descendants("span")
                .Where(y => y.HasClass("ipa") && y.HasClass("dipa"))
                .FirstOrDefault()?.InnerText)
                .Distinct();
        }
    }
}
