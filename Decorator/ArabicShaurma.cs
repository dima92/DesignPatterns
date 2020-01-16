using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Шаурма в арабском лаваше.
    /// </summary>
    public class ArabicShaurma : Shaurma
    {
        /// <summary>
        /// Создание экземпляра шаурмы в арабском лаваше.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        public ArabicShaurma(string name) : base(name + " в арабском лаваше")
        {
            Price += 15;
        }
    }
}
