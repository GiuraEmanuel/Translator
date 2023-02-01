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
            string inputOption;

            do
            {
                Console.WriteLine("Options list: ");
                for (int i = 0; i < _languages.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{_languages[i]}");
                }

                Console.WriteLine();
                Console.Write("Pick an option or type x/exit to exit: ");

                inputOption = Console.ReadLine().ToLower();
                var isNumber = int.TryParse(inputOption, out var option);


                if (isNumber)
                {
                    if (option > _languages.Count || option <= 0)
                    {
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine();
                        continue;
                    }

                    var language = _languages[option - 1];

                    Console.WriteLine($"You selected {language} option.");
                    Console.WriteLine();

                    Console.Write($"{language.From} : ");
                    var userInput = Console.ReadLine().ToLower();

                    var result = language.Translate(userInput);

                    Console.Write($"{language.To}: {result}");
                    Console.WriteLine();
                    Console.WriteLine();    
                }

            } while (inputOption != "x" && inputOption != "exit");
        }
    }
}
