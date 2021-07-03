using ScrapySharp.Network;
using System.Collections.Generic;
using System.Text;

namespace CambridgeDictionary.Cli
{
    public class CambridgeDictionaryCli : ICambridgeDictionaryCli
    {
        private readonly IScrapper _scrapper;

        public CambridgeDictionaryCli()
        {
            var scrapingBrowser = new ScrapingBrowser()
            {
                Encoding = Encoding.UTF8
            };
            _scrapper = new Scrapper(scrapingBrowser);
        }

        public CambridgeDictionaryCli(IScrapper scrapper)
        {
            _scrapper = scrapper;
        }

        /// <inheritdoc/>
        public EntrySet GetEntry(string word)
        {
            string headword = null;
            IEnumerable<string> similarWords = null;

            var page = _scrapper.GetPage(word);

            var entries = _scrapper.GetEntries(page);
            if (entries != null)
            {
                headword = GetHeadword(page);

            }
            else
            {
                similarWords = _scrapper.GetSimilarWords(page);
            }

            return new EntrySet
            {
                Headword = headword ?? word,
                Entries = entries,
                SimilarWords = similarWords,
                Raw = page.InnerHtml
            };
        }

        private string GetHeadword(HtmlAgilityPack.HtmlNode page)
        {
            var matchedWord = _scrapper.GetHeadword(page);
            var formattedWord = FormatWord(matchedWord);
            return formattedWord;
        }

        private static string FormatHeadline(string headline)
        {
            var definitions = headline.Split("definition: 1. ");
            if (definitions.Length > 1)
            {
                return definitions[1].Split(" 2. ")[0];
            }

            definitions = headline.Split("definition: ");

            return definitions[1].Replace(": . Learn more.", "");
        }

        private static string FormatWord(string word)
        {
            word = word.Replace("\"", "");
            return word;
        }
    }
}
