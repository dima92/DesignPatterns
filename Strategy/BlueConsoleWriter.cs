using System;

namespace Strategy
{
    /// <summary>
    /// Реализация стратегии вывода текста синим цветом.
    /// </summary>
    public class BlueConsoleWriter : IConsoleWriter
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

            // Устанавливаем синий цвет.
            Console.ForegroundColor = ConsoleColor.Blue;

            // Выводим на консоль.
            Console.WriteLine(text);
        }
    }
}