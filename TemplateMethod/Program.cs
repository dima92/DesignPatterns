using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем два вида пирога.
            var meatPie = new MeatPie();
            var applePie = new ApplePie();

            // Готовим мясной пирог.
            Console.WriteLine(meatPie);
            meatPie.Cook();
            Console.ReadLine();

            // Готовим яблочный пирог.
            Console.WriteLine(applePie);
            applePie.Cook();
            Console.ReadLine();
        }
    }
}
