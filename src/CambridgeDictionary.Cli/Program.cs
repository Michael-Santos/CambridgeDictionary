using ScrapySharp.Network;
using System;
using System.Web;

namespace CambridgeDictionary.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            const string urlBase = "https://dictionary.cambridge.org/search/direct/?datasetsearch=english&q=";

            const string word = "pull someone’s leg";

            var url = urlBase + HttpUtility.UrlEncode(word);

            var browser = new ScrapingBrowser();

            var homePage = browser.NavigateToPage(new Uri(url));

            Console.WriteLine(homePage.RawRequest);
            Console.WriteLine(homePage.RawResponse);

        }
    }
}
