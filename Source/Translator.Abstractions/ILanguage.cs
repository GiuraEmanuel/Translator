namespace Translator.Abstractions
{
    public interface ILanguage
    {
        public string From { get;}

        public string To { get; }

        string Translate(string sentence);
    }
}
