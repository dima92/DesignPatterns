using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Начало работы программы. Просим представиться клиента.
            Console.WriteLine("Здравствуйте. Вы обратились в службу заказа шаурты. Представьтесь, пожалуйста.");
            Console.Write("Ваше имя: ");
            var clientName = Console.ReadLine();
            Console.WriteLine("Ваш заказ уже начал готовиться.");
            Shaurma shaurma = null;

            // Просим клиента выбрать тип шаурмы. 
            // Повторяем до тех пор, пока пользователь не введет корректное значение.
            do
            {
                shaurma = GetShaurmaType(clientName);
            }
            while (shaurma == null);

            // Просим клиента выбрать добавки к шаурме.
            // Повторяем вопрос до тех пор, пока пользователь не откажется от добавки.
            while (true)
            {
                shaurma = GetShaurmaAdding(shaurma, out bool finish);
                if (finish)
                {
                    break;
                }
            }

            // Выводим сообщение о готовности шаурмы.
            Console.WriteLine($"{shaurma} готова. Стоимость {shaurma.Price} рублей.");
            Console.ReadLine();
        }

        /// <summary>
        /// Запросить о необходимости добавки в шаурму.
        /// </summary>
        /// <param name="shaurma">Шаурма, в которую может быть добавлена добавка.</param>
        /// <param name="finish">Добавление не нужно.</param>
        /// <returns>Шаурма после добавления добавки.</returns>
        private static Shaurma GetShaurmaAdding(Shaurma shaurma, out bool finish)
        {
            // По умолчанию добавки еще нужны.
            finish = false;

            // Выводим пользователю все возможные виды добавок
            // и сохраняем его ответ.
            Console.WriteLine("Хотите добавить особую добавку в шаурму?");
            foreach (AddingType t in Enum.GetValues(typeof(AddingType)))
            {
                Console.WriteLine($"{(int)t} - {t.GetDescription()}");
            }
            var adding = Console.ReadLine();

            // Пытаемя привести ответ пользователя к требуемому типу.
            if (int.TryParse(adding, out int addingType))
            {
                switch ((AddingType)addingType)
                {
                    case AddingType.None:
                        // Добавки больше не нужны.
                        // Возвращаем шаурму без изменений.
                        finish = true;
                        return shaurma;
                    case AddingType.Cheese:
                        // Добавляем сыр.
                        return new CheeseAdding(shaurma);
                    case AddingType.Ginger:
                        // Добавляем имбирь
                        return new GingerAdding(shaurma);
                    case AddingType.Mushroom:
                        // Добавляем грибы.
                        return new MushroomAdding(shaurma);
                    case AddingType.Spisy:
                        // Добавляем перца.
                        return new SpicyAdding(shaurma);
                    default:
                        // Не удалось привести ответ пользователя к требуемому виду.
                        // Введено число отсутствующее в перечислении типов добавок.
                        Console.WriteLine("Вы ввели некорректное значение!");
                        return shaurma;
                }
            }
            else
            {
                // Не удалось привести ответ пользователя к требуемому виду.
                // Введено не целое число.
                Console.WriteLine("Вы ввели некорректное значение!");
                return shaurma;
            }
        }

        /// <summary>
        /// Запросить у пользователя тип шаурмы.
        /// </summary>
        /// <param name="clientName">имя клиента.</param>
        /// <returns>Шаурма.</returns>
        private static Shaurma GetShaurmaType(string clientName)
        {
            // Выводим пользователю все возможные типы шаурмы
            // и сохраняем его ответ.
            Console.WriteLine($"{clientName}, выберите, пожалуйста, тип лаваша из представленных:");
            foreach (ShaurmaType t in Enum.GetValues(typeof(ShaurmaType)))
            {
                Console.WriteLine($"{(int)t} - {t.GetDescription()}");
            }
            var type = Console.ReadLine();

            // Пытаемя привести ответ пользователя к требуемому типу.
            if (int.TryParse(type, out int shaurmaType))
            {
                switch ((ShaurmaType)shaurmaType)
                {
                    case ShaurmaType.Standard:
                        // Шаурма в обычном лаваше.
                        return new StandardShaurma(clientName);
                    case ShaurmaType.Cheese:
                        // Шаурма в сырном лаваше.
                        return new CheeseShaurma(clientName);
                    case ShaurmaType.Arabic:
                        // Шаурма в арабском лаваше.
                        return new ArabicShaurma(clientName);
                    default:
                        // Не удалось привести ответ пользователя к требуемому виду.
                        // Введено число отсутствующее в перечислении видов шаурмы.
                        Console.WriteLine("Вы ввели некорректное значение!");
                        return null;
                }
            }
            else
            {
                // Не удалось привести ответ пользователя к требуемому виду.
                // Введено не целое число.
                Console.WriteLine("Вы ввели некорректное значение!");
                return null;
            }
        }
    }
}

