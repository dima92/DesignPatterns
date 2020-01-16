using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем наблюдаемый объект.
            var subject = new Subject("Объект 1");

            // Создаем наблюдателя.
            var observer = new Observer("Наблюдатель 1", subject);

            // Вызываем метод наблюдаемого объекта,
            // который создает событие.
            // Наблюдатель должен отреагировать на событие и
            // вывести сообщение на консоль.
            subject.Save();

            // Остановимся, чтобы увидеть результат.
            Console.ReadLine();
        }
    }
}
