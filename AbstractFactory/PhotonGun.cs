using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Фотонная пушка.
    /// </summary>
    public class PhotonGun : GunBase
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Минимально возможный урон.
        /// </summary>
        private readonly int _minDmg = 10;

        /// <summary>
        /// Максимально возможный урон.
        /// </summary>
        private readonly int _maxDmg = 80;

        /// <summary>
        /// Вероятность осечки.
        /// </summary>
        private readonly int _missСhance = 10;

        /// <inheritdoc />
        public override int Shoot()
        {
            // Не стабильный урон, может сильно выстрелить, может слабо, а может вовсе не выстрелить, но стреляет на большей дистанции.
            var miss = _random.Next(0, 100);
            if (miss < _missСhance)
            {
                return 0;
            }

            var dmg = _random.Next(_minDmg, _maxDmg);
            return dmg;
        }

        /// <summary>
        /// Создать экземпляр фотонной пушки.
        /// </summary>
        public PhotonGun()
        {
            Distance = 300;
        }
    }
}
