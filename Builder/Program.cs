using System;
using TextLib;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект текста.
            var text = new Text("Hello, World!");

            // Задаем форматирование текста.
            text.Font(Fonts.Georgia)
                .Size(18)
                .Color(ConsoleColor.Red)
                .BackgroundColor(ConsoleColor.Black)
                .Bold(true)
                .Underline(true);

            // Выводим форматированные текст.
            var html = text.Print();
            Console.WriteLine(html);
            Console.ReadLine();
        }
    }
}
