# CambridgeDictionary :book::books:
Porting a crawler to CSharp

# Dependencies
[ScrapySharp](https://github.com/rflechner/ScrapySharp)

# Purpose of this project
The main purpose of this project is provide a simple and conssitent lib to query the meaning of words on cambridge dictionary

# Features I mind to implement these following features
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

Currently, the lib only has an method called Meaning:

````C#
/// <summary>
/// Search for the meaning and other information of the word on the dictionary
/// </summary>
/// <param name="word">It's the word to be searched.</param>
/// <returns>The information about the word on the dictionary</returns>
Meaning GetMeaning(string word);
````

# Links
I'm lurking this other project implemented with TypeScript: [DevSnowflake/camb-dict](https://github.com/DevSnowflake/camb-dict)