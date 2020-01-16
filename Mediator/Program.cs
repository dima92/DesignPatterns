using Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создадим самолеты и взлетно-посадочные полосы.
            var aircrafts = new List<AircraftBase>()
            {
                new Boeing737("1"),
                new AirbusA320("2"),
                new Boeing737("3"),
                new Boeing737("4"),
                new AirbusA320("5")
            };
            var lands = new List<Land>()
            {
                new Land(1),
                new Land(2)
            };

            // Подписываемся на события изменения состояний самолетов и полос.
            aircrafts.ForEach(a => a.StateChanged += A_StateChanged);
            lands.ForEach(l => l.StateChanged += L_StateChanged);

            // Передаем диспетчеру в управление самолеты и взлетно-посадочные полосы.
            var dispetcher = new Dispatcher(aircrafts, lands);

            // Создаем отдельный поток, в котором диспетчер будет при необходимости отправлять самолеты в полет.
            var aircractStartThread = new Thread(() => Start(dispetcher));
            aircractStartThread.Start();
        }

        /// <summary>
        /// Поток отправки самолетов.
        /// </summary>
        /// <param name="dispetcher">Диспетчер управляющий полетами.</param>
        private static void Start(Dispatcher dispetcher)
        {
            while (true)
            {
                // Используем два генератора случайных чисел с разными шумом, 
                // чтобы была вероятность выпадения одинаковых чисел.
                var random1 = new Random(Convert.ToInt32(DateTime.Now.Ticks % int.MaxValue));
                var random2 = new Random(DateTime.Now.Millisecond);

                // 10 просто магическое число, определяющее вероятность вылета самолета.
                var dice1 = random1.Next(0, 10);
                var dice2 = random2.Next(0, 10);
                if (dice1 == dice2)
                {
                    var distance = random1.Next(10000, 40000);
                    Console.WriteLine(dispetcher.Send(distance));
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Обработчик события изменения состояния взлетно-посадочной полосы.
        /// </summary>
        /// <param name="sender">Взлетно-посадочная полоса.</param>
        /// <param name="e">Состояние полосы. true - полоса свободна, false - полоса занята.</param>
        private static void L_StateChanged(object sender, bool e)
        {
            var state = e ? "свободна" : "занята";
            Console.WriteLine($"Полоса {sender} {state}");
        }

        private static void A_StateChanged(object sender, AircraftState e)
        {
            Console.WriteLine($"Самолет {sender} находится в состоянии {e.GetDescription()}");
        }

    }
}