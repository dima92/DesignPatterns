using DI;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр майнера.
            Miner miner = new Miner();

            IAlgorithm algorithm = null;
            // Выбираем алгоритм.
            Console.WriteLine("Выберите алгоритм: ");
            Console.WriteLine("1 - SHA256");
            Console.WriteLine("2 - Ethash");
            var algorithmImput = Console.ReadLine();
            if (int.TryParse(algorithmImput, out int algo))
            {
                switch (algo)
                {
                    // Устанавливаем алгоритм.
                    case 1:
                        algorithm = new SHA256();
                        break;
                    case 2:
                        algorithm = new Ethash();
                        break;
                    default:
                        throw new ArgumentException("Неизвестный алгоритм.", nameof(algo));
                }
            }

            // Подписываемся на событие нахождения хеша.
            miner.HashFound += Miner_HashFound;

            // Начинаем майнинг.
            Console.WriteLine($"Начало майнинга {DateTime.Now.ToShortTimeString()}");
            miner.Start(algorithm);
        }

        /// <summary>
        /// Обработчик события нахождения хеша.
        /// </summary>
        /// <param name="sender">Майнер.</param>
        /// <param name="e">Корректность хеша.</param>
        private static void Miner_HashFound(object sender, bool e)
        {
            if (e)
            {
                Console.WriteLine("хеш найден");
            }
            else
            {
                Console.WriteLine("Некорректный хеш");
            }
        }
    }
}