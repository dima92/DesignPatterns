using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton = Singleton.GetInstance("Привет, мир!");
            var singleton2 = Singleton.GetInstance("Здравствуй, космос!");
            Console.WriteLine(singleton2.Data);
            Console.ReadLine();
        }
    }
}
