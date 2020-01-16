using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Базовый абстрактный класс описывающий возможности источников энергии космических кораблей.
    /// </summary>
    public abstract class EnergyBase
    {
        /// <summary>
        /// Количество оставшейся энергии источнике.
        /// </summary>
        public int Volume { get; protected set; }

        /// <summary>
        /// Использовать энергию из источника.
        /// </summary>
        /// <param name="volume">Количество потребляемой энергии.</param>
        /// <returns>Оставшаяся энергия в источнике.</returns>
        public abstract int Using(int volume);
    }
}
