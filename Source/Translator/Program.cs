using Translator;
using Translator.Abstractions;
using Translator.Languages.PigLatinAndEnglish;

var languages = new List<ILanguage> { new EnglishToPigLatin()};
var translatorApp = new TranslatorApplication(languages);
translatorApp.Run();