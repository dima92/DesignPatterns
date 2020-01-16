using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Источник энергии на основе плазмы.
    /// </summary>
    public class PlasmEnergy : EnergyBase
    {
        /// <inheritdoc />
        public override int Using(int volume)
        {
            if (volume < 0)
            {
                throw new ArgumentException("Расход топлива не может быть отрицательным.", nameof(volume));
            }

            // Обычный расход энергии при использовании.
            if (Volume >= volume)
            {
                Volume -= volume;
                return Volume;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Создать экземпляр источника энергии на основе плазмы.
        /// </summary>
        public PlasmEnergy()
        {
            Volume = 100;
        }
    }
}
