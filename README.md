# CambridgeDictionary :book::books:
A simple and consistent lib to query the meaning of words in the [Cambridge dictionary](https://dictionary.cambridge.org/).


# Dependencies
[ScrapySharp](https://github.com/rflechner/ScrapySharp)


# Features I mind implement
- [x] Meanings
- [x] Similar words sugestion
- [x] Phonetics


As I had implemented all the basics features but I'm going to enhance the results, performance, and documentation in the next few days.

# Next Steps
 - [x] Release alfa version
 - [x] Add method GetMeaningFromHtmlSource the avoid requests (Development utility)
 - [x] Enhence Debug Application to create and read \[word\].txt files with the source of the web pages the avoid requests (Development utility)
 - [ ] Setup a simple CI/CD mechanism on Github - (It's only building when something is pushed to master branch at the moment)
 - [ ] Unit Tests


# Nuget
The lib is finally available on Nuget: https://www.nuget.org/packages/MrBroccoli.CambridgeDictionary.Cli.


# Setup

## DI

You can setup the lib in your DI container as follow and then pass the ```ICambridgeDictionaryCli``` interface in the constructor of your services.

```C#
using CambridgeDictionary.Cli.Extensions;

...

serviceCollection.AddCambridgeDictionary();
```

```C#
using CambridgeDictionary.Cli;

...

public class Service {
    
    private readonly _cambridgeDictionaryCli;

    public YourService(ICambridgeDictionaryCli cambridgeDictionaryCli) {
        _cambridgeDictionaryCli = cambridgeDictionaryCli;
    }

    ...

}
```


## Without DI

It's just needed to import the lib and then create a new instance of the class ```CambridgeDictionaryCli```.

```C#
using CambridgeDictionary.Cli;

...

var cambridgeDictionary = new CambridgeDictionaryCli();
```


# Usage

Currently, the lib has the two methods as follow:

````C#
/// <summary>
/// Search for entries of the word in dictionary
/// </summary>
/// <param name="word">The word to be searched.</param>
/// <returns>The information about the word on the dictionary</returns>
EntrySet GetEntry(string word);

/// <summary>
/// Fetch the entries of the word in dictionary directly from a html source
/// </summary>
/// <param name="htmlSource">The html source</param>
/// <returns>The information about the word on the dictionary</returns>
EntrySet GetEntryFromHtmlSource(string htmlSource);
````


# Return

A EntrySet looks like this:

```
EntrySet - Represts a set of entries of the searched word
{
    string Headword - Represents the searched word,
    string Headline - Small definition fetched from metatag from web page
    [
        Entry - Represents an entry in dictionary
        {
            string Type - The word class,
            IPA - International Phonetic Alphabet, the phonetic transcription of the word's pronunciation
            {
               [
                    string> UK - UK pronounces,
                    ...
               ],
               [
                    string US - US pronounces,
                    ...
               ]
                
            },
            [   
                Senses - A possible meaning of the word
                {
                    string GuideWord - It's a word that helps you find the right meaning when a word has more than one meaning,
                    [ 
                        Definitions - A set of definition of the sense of the word
                        {
                            string Text - The definition itself,
                            [
                                string Examples - Examples of use of the word in the specific definition,
                                ...
                            ]
                        }
                    ]
                },
                ...
            ],
        }
    ],
    [
        string SimilarWords - Similar words sugestion when the searched word wasn't found,
        ...
    ],
    string Raw - The raw meaning page   
}

```

# Debug Tools

## Runner

Text's still in development


# Links
I'm lurking this other two project:

 - [DevSnowflake/camb-dict](https://github.com/DevSnowflake/camb-dict) - project implemented with TypeScript
 - [qas612820704/cambridge-dictionary](https://github.com/qas612820704/cambridge-dictionary) - project implemented with JavaScript

This link help me to understand the dictionary anatomy:

 - [Macmillandictionary](https://www.macmillandictionary.com/learn/dictionary-entry.html) - Dictionary anatomy

