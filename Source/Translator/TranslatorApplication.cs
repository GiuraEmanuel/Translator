using Translator.Abstractions;

namespace Translator
{
    public class TranslatorApplication
    {
        private readonly List<ILanguage> _languages;

        public TranslatorApplication(List<ILanguage> languages)
        {
            _languages = languages;
        }

        public void Run()
        {
            string optionInput;

            do
            {
                Console.WriteLine("Options list: ");
                for (int i = 0; i < _languages.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{_languages[i]}");
                }

                Console.WriteLine();
                Console.Write("Pick an option or type x/exit to exit: ");

                optionInput = Console.ReadLine().ToLower();
                var isNumber = int.TryParse(optionInput, out var option);

                if (isNumber)
                {
                    if (option <= _languages.Count && option > 0)
                    {
                        Console.WriteLine($"You selected {_languages[option - 1]} option.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine();
                        continue;
                    }

                    Console.Write($"{_languages[option - 1].From} : ");
                    var userInput = Console.ReadLine().ToLower();

                    var result = _languages[option - 1].Translate(userInput);

                    Console.Write($"{_languages[option - 1].To}: {result}");
                    Console.WriteLine();
                    Console.WriteLine();    
                }

            } while (optionInput != "x" && optionInput != "exit");
        }
    }
}
