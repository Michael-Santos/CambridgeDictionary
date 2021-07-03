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

        /// <inheritdoc/>
        public HtmlNode GetPage(string word)
        {
            var url = _urlBase + HttpUtility.UrlEncode(word);
            return _browser.NavigateToPage(new Uri(url)).Html;
        }

        /// <inheritdoc/>
        public string GetHeadline(HtmlNode page)
        {
            var node = page.SelectSingleNode("//meta[@itemprop='headline']");
            var contentAttributeValue = node.GetAttributeValue("content", "");
            return HttpUtility.HtmlDecode(contentAttributeValue);
        }

        /// <inheritdoc/>
        public string GetHeadword(HtmlNode page)
        {
            var node = page.SelectSingleNode("//div[@class='di-title']/span");

            if (node == null)
            {
                node = page.SelectSingleNode("//div[@class='di-title']/h2/b");
            }

            return node.InnerText;
        }

        /// <inheritdoc/>
        public IEnumerable<Entry> GetEntries(HtmlNode page)
        {
            var nodes = page.SelectNodes("//div[@class='pr dictionary']");

            if (nodes == null)
            {
                return null;
            }
            
            var entrySet = new List<Entry>();

            foreach (var node in nodes)
            {
                entrySet.AddRange(ExtractEntries(node));
            }

            return entrySet;
        }

        private static bool HasMultipleEntries(HtmlNode page)
        {
            return page.SelectSingleNode("//div[@class='entry']") != null;
        }

        private IEnumerable<Entry> ExtractEntries(HtmlNode page)
        {
            var entries = new List<Entry>();

            var hasMulipleEntries = HasMultipleEntries(page);
            
            IEnumerable<HtmlNode> entryBodyNodeElementNodes = GetEntryBlockElement(page, hasMulipleEntries);

            foreach (var entryBodyNodeElementNode in entryBodyNodeElementNodes)
            {
                var entry = new Entry();

                entry.Type = hasMulipleEntries ? ExtractType(entryBodyNodeElementNode) : "phrasal verb/other";
                entry.Ipa = hasMulipleEntries ? GetPhonetics(entryBodyNodeElementNode) : new Ipa();

                var senses = new List<Sense>();

                var dsenseNodes = entryBodyNodeElementNode.Descendants().Where(x => x.HasClass("dsense"));
                foreach (var dsense in dsenseNodes)
                {
                    var guideWord = ExtractGuideWord(dsense);
                    var definitions = ExtractDefinitions(dsense);

                    var sense = new Sense
                    {
                        GuideWord = guideWord,
                        Definitions = definitions
                    };

                    senses.Add(sense);
                }
                entry.Senses = senses;
                entries.Add(entry);
            }

            return entries;
        }

        private static IEnumerable<HtmlNode> GetEntryBlockElement(HtmlNode page, bool hasMulipleEntries)
        {
            Func<HtmlNode, bool> elementClasses = hasMulipleEntries ?
                            x => x.HasClass("entry-body__el") :
                            x => x.HasClass("idiom-block") && x.HasClass("pr");

            var entryBodyNodeElementNodes = page.Descendants().Where(elementClasses);
            return entryBodyNodeElementNodes;
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

            if (guideWordNode == null)
            {
                return null;
            }

            return guideWordNode.InnerText.Trim(' ', '\n', '(', ')');
        }

        private IEnumerable<Definition> ExtractDefinitions(HtmlNode node)
        {
            var definitions = new List<Definition>();

            var entryNodes = node.Descendants()
                .Where(x => x.HasClass("def-block"));

            foreach (var entryNode in entryNodes)
            {
                var definition = ExtractDefinition(entryNode);
                var examples = ExtractExamples(entryNode);

                var entry = new Definition
                {
                    Text = definition,
                    Examples = examples
                };

                definitions.Add(entry);
            }

            return definitions;
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public Ipa GetPhonetics(HtmlNode page)
        {
            var ukPhonetics = ExtractPhonetics(page, "uk");
            var usPhonetics = ExtractPhonetics(page, "us");

            if (ukPhonetics == null && usPhonetics == null)
            {
                return null;
            }

            return new Ipa
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
                .FirstOrDefault()?.InnerText);
        }
    }
}
