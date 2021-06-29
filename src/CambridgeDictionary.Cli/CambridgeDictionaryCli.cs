using System;
using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    public class CambridgeDictionaryCli : ICambridgeDictionaryCli
    {
        private readonly IScrapper _scrapper;

        public CambridgeDictionaryCli(IScrapper scrapper)
        {
            _scrapper = scrapper;
        }

        public Meaning GetMeaning(string word)
        {
            var page = _scrapper.GetPage(word);
            var headline = _scrapper.GetHeadline(page);
            var headlineFormatted = FormatHeadline(headline);

            return new Meaning
            {
                Word = word,
                HeadLine = headlineFormatted,
                Raw = page.InnerHtml
            };
        }

        private static string FormatHeadline(string headline)
        {
            var definitions = headline.Split("definition: 1. ");
            if (definitions.Length > 1) {
                return definitions[1].Split(" 2. ")[0];
            }

            definitions = headline.Split("definition: ");

            return definitions[1];
        }

        public IEnumerable<string> GetSimilarWords(string word)
        {
            throw new NotImplementedException();
        }
    }
}
