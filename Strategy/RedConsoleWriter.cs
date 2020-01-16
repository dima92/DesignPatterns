using System;

namespace Strategy
{
    /// <summary>
    /// Реализация стратегии вывода текста красным цветом.
    /// </summary>
    public class RedConsoleWriter : IConsoleWriter
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

            // Устанавливаем красный цвет.
            Console.ForegroundColor = ConsoleColor.Red;

            // Выводим на консоль.
            Console.WriteLine(text);
        }
    }
}