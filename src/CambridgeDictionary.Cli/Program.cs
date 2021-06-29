using ScrapySharp.Network;
using System;
using System.Text;
using System.Web;

namespace CambridgeDictionary.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = "pull someone's leg";
            
            var cambridge = new CambridgeDictionaryCli();
            var meaning = cambridge.GetMeaning(word);
        }
    }
}
