using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Abstractions;

namespace Translator.Languages.PigLatinAndEnglish
{
    public class EnglishToPigLatin : ILanguage
    {
        public string From => "English";

        public string To => "Pig Latin";

        public string Translate(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence)) // return if the sentence is empty
            {
                return null;
            }

            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            var words = sentence.Split(' ');
            var translatedWords = new List<string>();

            foreach (var word in words)
            {
                var firstVowelIndex = word.IndexOfAny(vowels);
                var pigLatinSuffix = "ay";

                // if first letter is a vowel or if the word doesn't contain any vowels at all
                // then suffix the word with "ay"
                // "equivalent to firstVowelIndex == 0 || firstVowelIndex == - 1"
                if (firstVowelIndex <= 0) 
                {
                    var translatedWord = word + pigLatinSuffix;
                    translatedWords.Add(translatedWord);
                }
                else // first letter of the word is a consonant
                {
                    var wordConsonants = word.Substring(0, firstVowelIndex);
                    var wordWithConsonantsRemoved = word.Remove(0, wordConsonants.Length);

                    var translatedWord = wordWithConsonantsRemoved + wordConsonants + pigLatinSuffix;

                    translatedWords.Add(translatedWord);
                }
            }

            var translatedSentence = string.Join(" ", translatedWords);
            return translatedSentence;
        }

        public override string ToString()
        {
            return $"{From} to {To}";
        }
    }
}
