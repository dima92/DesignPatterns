using System;

namespace Strategy
{
    /// <summary>
    /// Реализация стратегии вывода текста зеленым цветом.
    /// </summary>
    public class GreenConsoleWriter : IConsoleWriter
    {
        /// <summary>
        /// Вывод текста на консоль.
        /// </summary>
        /// <param name="text"> Выводимый текст. </param>
        public void WriteText(string text)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            // Устанавливаем зеленый цвет.
            Console.ForegroundColor = ConsoleColor.Green;

            // Выводим на консоль.
            Console.WriteLine(text);
        }
    }
}