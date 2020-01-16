using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Источник энергии на основе солнечной радиации.
    /// </summary>
    public class SunEnergy : EnergyBase
    {
        /// <inheritdoc />
        public override int Using(int volume)
        {
            if (volume < 0)
            {
                throw new ArgumentException("Расход топлива не может быть отрицательным.", nameof(volume));
            }

            // Пусть это будет идеальный бесконечный источник энергии.
            return Volume;
        }

        /// <summary>
        /// Создать экземпляр источника энергии на основе солнечной радиации.
        /// </summary>
        public SunEnergy()
        {
            Volume = 100;
        }
    }
}
