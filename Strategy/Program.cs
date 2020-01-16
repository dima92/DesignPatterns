using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задаем количество строк, которые будут выведены на экран.
            var count = 25;

            // Задаем задержку между выводом сообщений на консоль.
            var delay = TimeSpan.FromSeconds(1);

            // Создаем коллекцию из конкретных реализаций стратегии.
            // Обратите внимание, что мы используем тип IConsoleWriter,
            // что позволяет разместить в эту коллекцию любой класс,
            // который реализует данный интерфейс стратегии.
            var writers = new IConsoleWriter[]
            {
                new RedConsoleWriter(),
                new BlueConsoleWriter(),
                new GreenConsoleWriter()
            };

            // Простой цикл, чтобы вывести на консоль текст заданное количество раз.
            for (var i = 0; i < count; i++)
            {
                // Получаем индекс элемента из коллекции остатком от деления
                // текущего номера итерации на общее количество элементов в коллекции.
                var index = i % writers.Length;

                // Получаем конкретную реализацию стратегии.
                var writer = writers[index];

                // Подготавливаем случайный текст, который будет выведен на экран.
                var text = Guid.NewGuid().ToString();

                // Выводим текст конкретной реализацией стратегии.
                writer.WriteText(text);

                // Ждем заданный промежуток времени, чтобы выполнялось не слишком быстро.
                Thread.Sleep(delay);
            }

            // Ждем завершения.
            Console.ReadLine();
        }
    }
}

