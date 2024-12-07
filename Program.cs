using System;

namespace VoiceToTextAdapter
{
    // Інтерфейс текстових команд
    // Цей інтерфейс визначає метод, який повинна реалізувати будь-яка текстова команда
    public interface ITextCommand
    {
        // Отримати текст команди
        string GetCommand();
    }

    // Клас для текстових команд
    // Реалізує інтерфейс ITextCommand, щоб надати доступ до текстових команд
    public class TextCommand : ITextCommand
    {
        private readonly string _command; // Поле для збереження тексту команди

        // Конструктор приймає текст команди під час створення об'єкта
        public TextCommand(string command)
        {
            _command = command;
        }

        // Реалізація методу GetCommand для отримання тексту команди
        public string GetCommand()
        {
            return _command;
        }
    }

    // Імітація сторонньої бібліотеки для роботи з голосовими командами
    // Цей клас імітує роботу з голосовими командами, наприклад, через мікрофон
    public class VoiceCommandRecognizer
    {
        // Метод для розпізнавання голосової команди
        // У реальному світі це може бути інтеграція з API або бібліотекою обробки голосу
        public string RecognizeVoiceCommand()
        {
            // Для прикладу, повертаємо готову команду
            return "Turn on the lights"; // Симулюємо результат розпізнавання
        }
    }

    // Адаптер для перетворення голосових команд у текстові
    // Реалізує інтерфейс ITextCommand і працює з VoiceCommandRecognizer
    public class VoiceToTextAdapter : ITextCommand
    {
        private readonly VoiceCommandRecognizer _voiceCommandRecognizer; // Поле для роботи з голосовим розпізнавачем

        // Конструктор приймає об'єкт VoiceCommandRecognizer для адаптації його функціоналу
        public VoiceToTextAdapter(VoiceCommandRecognizer voiceCommandRecognizer)
        {
            _voiceCommandRecognizer = voiceCommandRecognizer;
        }

        // Реалізація методу GetCommand
        // Викликає метод розпізнавання голосу та повертає отриманий текст
        public string GetCommand()
        {
            return _voiceCommandRecognizer.RecognizeVoiceCommand();
        }
    }

    // Головний клас для демонстрації роботи системи
    public class Program
    {
        public static void Main(string[] args)
        {
            // Демонстрація роботи з текстовою командою
            // Створюємо текстову команду та викликаємо метод GetCommand
            ITextCommand textCommand = new TextCommand("Play music");
            Console.WriteLine("Text Command: " + textCommand.GetCommand());

            // Демонстрація роботи з голосовою командою через адаптер
            // Створюємо об'єкт VoiceCommandRecognizer
            VoiceCommandRecognizer voiceRecognizer = new VoiceCommandRecognizer();

            // Передаємо його в адаптер, який реалізує ITextCommand
            ITextCommand voiceCommand = new VoiceToTextAdapter(voiceRecognizer);

            // Отримуємо текстову версію голосової команди через адаптер
            Console.WriteLine("Voice Command (as Text): " + voiceCommand.GetCommand());
        }
    }
}
