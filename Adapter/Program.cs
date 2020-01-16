using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создадим новый обычный кассовый аппарат.
            var cashMachineStandart = new CashMachine();
            var cashMacineForeign = new ForeignCashMachine.ForeignCashMachine();

            // Создадим список товаров, которые будут добавлены в чек.
            var products = new List<Product>
            {
                new Product("Samsung SSD 256Gb", 9600),
                new Product("Crucial RAM DDR3 4Gb", 2500),
                new Product("Intel CPU Core-i7 6400", 8000)
            };

            // Проверяем обычный кассовый аппарат.
            TestCashMachine(cashMachineStandart, products);

            // Создаем и проверяем иностранный кассовый аппарат.
            var cashMacineForeignAdapter = new ForeignCashMachineAdapter(cashMacineForeign);
            TestCashMachine(cashMacineForeignAdapter, products);
        }

        private static void TestCashMachine(ICashMachine cashMachine, List<Product> products)
        {
            // Добавляем товары в чек.
            products.ForEach(p => cashMachine.AddProduct(p));

            // Печатаем чек и сохраняем его в переменную.
            var check = cashMachine.PrintCheck();

            // Выводим результат работы с обычным кассовым аппаратом на экран.
            Console.WriteLine(check);
            Console.ReadLine();
        }
    }
}

