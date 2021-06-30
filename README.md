# CambridgeDictionary :book::books:
Porting a crawler to CSharp

# Dependencies
[ScrapySharp](https://github.com/rflechner/ScrapySharp)

# Purpose of this project
The main purpose of this project is provide a simple and conssitent lib to query the meaning of words on cambridge dictionary

# Features I mind to implement
- [x] Meanings
- [x] Similar words sugestion
- [ ] Phonetics



# Setup
The lib isn't still available on Nuget.org :worried::weary::sweat_smile:, but I mind to keep the usage as simples as possible.

You just need add it to you service collection as follow:

````C#
services.AddCambridgeDictionary();
````

After that the lib is already available to use.

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
    string Headline - The definition fetched from a meta attribute insted of reading all the page
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
    IEnumerable<string> SimilarWords - Similar words sugestion when the searched word wasn't found
    string Raw - The raw meaning page
}

```


# Links
I'm lurking this other project implemented with TypeScript: [DevSnowflake/camb-dict](https://github.com/DevSnowflake/camb-dict)