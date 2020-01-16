using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Шаурма в обычном лаваше.
    /// </summary>
    public class StandardShaurma : Shaurma
    {
        /// <summary>
        /// Создание нового экземпляра шаурмы в обычном лаваше.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        public StandardShaurma(string name) : base(name + " в обычном лаваше")
        {
        }
    }
}
