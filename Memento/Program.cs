using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать на 77-ые Космические игры! Представьтесь...");

            // Запрашиваем имя пользователя, пока он ни введет не пустую строку.
            var name = "";
            while (true)
            {
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Введите Ваше имя!");
                }
                else
                {
                    break;
                }
            }

            // Создаем хранилище состояний.
            var carataker = new CaratakerSpaceship();

            // Счетчик побед. 
            var winCounter = 0;

            // Создаем космический корабль игрока.
            var playerShip = new Spaceship(name, 300);

            // Повторяем пока пользователь не выйдет.
            while (true)
            {
                // Создаем космический корабль противника.
                var computerShip = new Spaceship($"Гладиатор №{winCounter + 1}");

                // Представляем участников и создаем объект сражения с этими участниками.
                Console.WriteLine($"Первый претендент: {playerShip}. Уровень здоровья {playerShip.Health}.");
                Console.WriteLine($"Второй претендент: {computerShip}. Уровень здоровья {computerShip.Health}");

                var battle = new Battle(playerShip, computerShip);

                // Запрашиваем у пользователя продолжение.
                Console.WriteLine("Да начнется смертельная битва! Продолжить?(y/n)");
                var ansver = Console.ReadLine();

                if (ansver.ToLower() == "y")
                {
                    // Если пользователь согласился, то начинаем битву.
                    var battleWinner = battle.Fight();

                    if (battleWinner == playerShip)
                    {
                        // Если выиграл пользователь, то поздравляем его, сохраняем новый снимок и переходим к следующему туру.
                        Console.WriteLine($"Поздравляем! Вы выиграли в битве, {battleWinner}");

                        // Формируем снимок корабля и сохраняем снимок в хранилище снимков.
                        var saveMemento = playerShip.Save();
                        carataker.Save(saveMemento);

                        // Увеличиваем количество побед.
                        winCounter++;
                        continue;
                    }
                    else
                    {
                        // Если выиграл компьютер, то предлагаем загрузиться из последнего сохранения.
                        Console.WriteLine("Сожалеем, но вы погибли в сражении. Загрузить последнее сохранение?(y/n)");
                        var answer2 = Console.ReadLine();
                        if (ansver.ToLower() == "y")
                        {
                            // Если пользователь согласился, то загружаем игру и начинаем раунд заново.

                            // Загружаем состояние.
                            var loadMemento = carataker.Restore();
                            playerShip.Restore(loadMemento);

                            // Сообщаем пользователю.
                            Console.WriteLine("Игра загружена. Нажмите ввод, чтобы продолжить.");
                            Console.ReadLine();
                            continue;
                        }
                        else if (ansver.ToLower() == "n")
                        {
                            // Иначе если пользователь отказался загружаться, то сообщаем количество побед.
                            Console.WriteLine($"Вы доблестно победили в {winCounter} битвах и погибли с честью.");
                            Console.ReadLine();
                            break;
                        }
                    }
                }
                else if (ansver.ToLower() == "n")
                {
                    // Иначе если пользователь отказался сражаться, то сообщаем ему результат.
                    if (winCounter == 0)
                    {
                        Console.WriteLine("Вы с позором отказались от битвы, но остались целы и невредимы.");
                    }
                    else
                    {
                        Console.WriteLine($"Поздравляем! Вы с доблестью выиграли {winCounter} сражений и уходите победителем.");
                    }
                    break;
                }

                // Был введен некорректный ответ.
                Console.WriteLine("Некорректный ввод ответа. " +
                        "Если хотите продолжить, введите английский символ y, " +
                        "если хотите отказаться, введите английский символ n.");
            }

            // Игра завершена.
            Console.WriteLine("Игра завершена.");
            Console.ReadLine();
        }
    }
}
