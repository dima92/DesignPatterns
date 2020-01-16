using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            // Проверяем как ведут себя значимые типы данных.
            // Создаем два объекта, во второй помещаем первый,
            // а затем изменяем второй. Первый остается неизменным.
            var int1 = 5;
            var int2 = int1;
            int2 = 7;
            Console.WriteLine(int1);
            Console.ReadLine();

            // Проверяем как ведут себя обычные ссылочные типы данных.
            // Создаем два объекта, во второй помещаем первый,
            // а затем изменяем второй. Первый объект тоже изменился.
            var text1 = new Text("Hello, World!");
            var text2 = text1;
            text2.Content = "Good bay, World!";
            Console.WriteLine(text1.Content);
            Console.ReadLine();

            // Проверяем как ведут себя клонируемые объекты.
            // Создаем два объекта, во второй помещаем клон первого,
            // а затем изменяем второй. Первый остается неизменным.
            var cloneText1 = new TextCloneable("Hello, World!");
            var cloneText2 = cloneText1.Clone() as TextCloneable
                ?? throw new NullReferenceException("Не удалось выполнить приведение типа");
            cloneText2.Content = "Good bay, World!";
            Console.WriteLine(cloneText1.Content);
            Console.ReadLine();
        }
    }
}
