# CambridgeDictionary :book::books:
A simple and consistent lib to query the meaning of words on the Cambridge dictionary

# Dependencies
[ScrapySharp](https://github.com/rflechner/ScrapySharp)

# Features I mind implement
- [x] Meanings
- [x] Similar words sugestion
- [x] Phonetics

As I had implemented all the basics features I'm going to enhance the results, performance, and documentation in the next few days to get an alfa version ASAP.

# Next Steps
 - [x] Release alfa version
 - [ ] Setup a simple CI/CD mechanism on Github
 - [ ] Unit Tests

# Nuget
The lib is finally available on Nuget: https://www.nuget.org/packages/MrBroccoli.CambridgeDictionary.Cli

# Setup
You just need to add it to your service collection as follow:

````C#
using CambridgeDictionary.Cli.Extensions;

--

var serviceCollection = new ServiceCollection();
serviceCollection.AddCambridgeDictionary();

var serviceProvider = serviceCollection.BuildServiceProvider();
var cambridgeDictionary = serviceProvider.GetService<ICambridgeDictionaryCli>();
````

After that, the lib would be available to use.

# Usage

Currently, the lib only has an method called GetMeaning:

````C#
/// <summary>
/// Search for the meaning and other information of the word on the dictionary
/// </summary>
/// <param name="word">It's the word to be searched.</param>
/// <returns>The information about the word on the dictionary</returns>
Meaning GetMeaning(string word);
````

# Response

The Meaning response looks like this:

```
{
    string Word - Word you searched
    string Headline - The definition fetched from a meta attribute instead of reading all the page
    IEnumerable<EntrySet> EntrySets - All the possible meanings with examples and guide word whether it's available
    {
        string GuideWord - Word that helps you find the right meaning when a word has more than one meaning
        IEnumerable<Entry> Entries
        {
            string Type - The word class
            string Definition - The meaning itself
            IEnumerable<string> Examples - Examples of sentences using the searched word
        }
    }
    IEnumerable<string> SimilarWords - Similar words suggestion when the searched word wasn't found
    string Raw - The raw meaning page
}

```


# Links
I'm lurking this other two project:

 - [DevSnowflake/camb-dict](https://github.com/DevSnowflake/camb-dict) - project implemented with TypeScript
 - [qas612820704/cambridge-dictionary](https://github.com/qas612820704/cambridge-dictionary) - project implemented with JavaScript