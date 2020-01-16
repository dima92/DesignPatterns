using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Базовый абстрактный класс, описывающий возможности оружия космических кораблей.
    /// </summary>
    public abstract class GunBase
    {
        /// <summary>
        /// Максимально возможная дистанция между комическими кораблями для выстрела из оружия.
        /// </summary>
        public int Distance { get; protected set; }

        /// <summary>
        /// Выстрелить из оружия.
        /// </summary>
        /// <returns>Количество нанесенного урона.</returns>
        public abstract int Shoot();
    }
}
