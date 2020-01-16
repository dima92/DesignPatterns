using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать на 76-ые Космические игры...");
            Console.ReadLine();

            var piratShip = new Spaceship("Навуходоносор", new PiratSpaceshipFactory());
            var warShip = new Spaceship("Ностромо", new WarSpaceshipFactory());

            Console.WriteLine($"Первый претендент: {piratShip}");
            Console.WriteLine($"Второй претендент: {warShip}");
            Console.ReadLine();

            var battle = new Battle(piratShip, warShip);

            Console.WriteLine("Поехали!");
            Console.ReadLine();

            var raceWinner = battle.Race();
            if (raceWinner != null)
            {
                Console.WriteLine($"Поприветствуйте победителя гонки {raceWinner}");
            }
            else
            {
                Console.WriteLine("В гонке ничья");
            }
            Console.ReadLine();

            Console.WriteLine("Да начнется смертельная битва!");
            Console.ReadLine();

            var battleWinner = battle.Fight();
            if (battleWinner != null)
            {
                Console.WriteLine($"Поприветствуйте победителя сражения {battleWinner}");
            }
            else
            {
                Console.WriteLine("В битве ничья");
            }
            Console.ReadLine();
        }
    }
}
