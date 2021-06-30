﻿using System;
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
            var matchedWord = _scrapper.GetWord(page);
            var formattedWord = FormatWord(matchedWord);

            var entries = _scrapper.GetEntries(page);
            var similarWords = _scrapper.GetSimilarWords(page);
            
            return new Meaning
            {
                Word = formattedWord,
                Headline = headlineFormatted,
                EntrieSets = entries,
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

            return definitions[1].Replace(": . Learn more.", "");
        }

        private static string FormatWord(string word)
        {
            word = word.Replace("<span class=\"obj dobj\">", "");
            word = word.Replace("</span>", "");
            word = word.Replace("\"", "");
            return word;
        }

        public IEnumerable<string> GetSimilarWords(string word)
        {
            throw new NotImplementedException();
        }
    }
}
