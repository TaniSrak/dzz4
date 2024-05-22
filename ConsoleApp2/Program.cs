namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1. Перевести текст в азбуку Морзе");
                Console.WriteLine("2. Перевести азбуку Морзе в текст");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите текст для перевода в азбуку Морзе:");
                        string textToMorse = Console.ReadLine().ToUpper(); //считываем
                        string morseCode = MorseCodeTranslator.TextToMorse(textToMorse); //конвертируем
                        Console.WriteLine($"Текст в азбуке Морзе: {morseCode}");
                        break;

                    case "2":

                        Console.WriteLine("Введите азбуку Морзе для перевода в текст (разделяйте символы пробелом):");
                        string morseToText = Console.ReadLine();
                        string plainText = MorseCodeTranslator.MorseToText(morseToText);
                        Console.WriteLine($"Текст: {plainText}");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                
                }
            
            }
        }

        public static class MorseCodeTranslator //класс для перевода
        {
            //словарь из текста в морзе
            private static readonly Dictionary<char, string> _textToMorse = new Dictionary<char, string>()
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
                {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
                {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
                {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
                {'0', "-----"}, {' ', "/"}, {',', "--..--"}, {'.', ".-.-.-"}, {'?', "..--.."},
                {'!', "-.-.--"}, {'-', "-....-"}, {'/', "-..-."}, {'@', ".--.-."}, {'(', "-.--."},
                {')', "-.--.-"}
            };

            //словарь из морзе в текст
            private static readonly Dictionary<string, char> _morseToText = new Dictionary<string, char>();

            static MorseCodeTranslator() //заполняем словарь из морзе в текстк
            {
                foreach (var pair in _textToMorse) 
                {
                    _morseToText[pair.Value] = pair.Key;
                }
            }

            public static string TextToMorse(string text) //перевод в морзе
            { 
                var morseCode = new List<string>(); //я не понимаю, почему у меня работает только с var

                foreach (char c in text)
                {
                    if (_textToMorse.ContainsKey(c))
                    {
                        morseCode.Add(_textToMorse[c]);
                    }
                    else
                    {
                        morseCode.Add("?"); //если не нашли символ
                    }
                }
                return string.Join(" ", morseCode); //делаем из списка строку сразу в результате
            }

            //перевод из морзе в текст
            public static string MorseToText(string morse)
            {
                var text = new List<char>();
                var morseSymbols = morse.Split(' ');

                foreach (string symbol in morseSymbols)
                {
                    if (_morseToText.ContainsKey(symbol))
                    {
                        text.Add(_morseToText[symbol]);
                    }
                    else
                    {
                        text.Add('?');
                    }
                }
                return new string(text.ToArray());
            }
        }
    }
}
