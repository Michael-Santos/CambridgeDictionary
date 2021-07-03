using HtmlAgilityPack;
using System.Collections.Generic;

namespace CambridgeDictionary.Cli
{
    /// <summary>
    /// A service to crawl information from the Cambridge Dictionary
    /// </summary>
    public interface IScrapper
    {
        /// <summary>
        /// Requests the web page of the dictionary
        /// </summary>
        /// <param name="word">The word to search</param>
        /// <returns>The <c>HtmlNode</c> that allows you navigate throghout the page</returns>
        HtmlNode GetPage(string word);

        /// <summary>
        /// Get the headline from web page
        /// </summary>
        /// <param name="page">Represents the web page</param>
        /// <returns>The headline</returns>
        string GetHeadline(HtmlNode page);

        /// <summary>
        /// Get the headword from web page
        /// </summary>
        /// <param name="page">Represents the web page</param>
        /// <returns>The headword</returns>
        string GetHeadword(HtmlNode page);

        /// <summary>
        /// Get a list of entries for the seached word from the web page
        /// </summary>
        /// <param name="page">Represents the web page</param>
        /// <returns>The list list of entries <c>Entry</c></returns>
        IEnumerable<Entry> GetEntries(HtmlNode page);

        /// <summary>
        /// Get the phonetics from web page
        /// </summary>
        /// <param name="page">Represents the web page</param>
        /// <returns>The phonetics <c>Ipa</c> for the word</returns>
        Ipa GetPhonetics(HtmlNode page);
        IEnumerable<string> GetSimilarWords(HtmlNode page);
    }
}
