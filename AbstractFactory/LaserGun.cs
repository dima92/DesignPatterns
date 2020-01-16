using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Лазерная пушка.
    /// </summary>
    public class LaserGun : GunBase
    {
        /// <inheritdoc />
        public override int Shoot()
        {
            // Стреляет не сильно, но стабильно
            return 30;
        }

        /// <summary>
        /// Создать экземпляр лазерной пушки.
        /// </summary>
        public LaserGun()
        {
            Distance = 100;
        }
    }
}
