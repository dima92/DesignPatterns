using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Базовый класс шаурмы.
    /// </summary>
    public abstract class Shaurma
    {
        /// <summary>
        /// Название шаурмы.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public int Price { get; protected set; }

        /// <summary>
        /// Создание нового экземпляра шаурмы.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        public Shaurma(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Price = 100;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Полное название шаурмы.</returns>
        public override string ToString()
        {
            return $"Шаурма для клиента по имени {Name}";
        }
    }
}
