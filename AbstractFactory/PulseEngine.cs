using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Импульсный двигатель.
    /// </summary>
    public class PulseEngine : EngineBase
    {
        /// <summary>
        /// Множитель скорости полета.
        /// </summary>
        private readonly int _speedFactor = 5;

        /// <inheritdoc />
        public override int Move(EnergyBase energy)
        {
            if (energy == null)
            {
                throw new ArgumentNullException(nameof(energy));
            }

            // Стандартный режим полета. Не очень быстро, но стабильно.
            var baseSpeed = base.Move(energy);
            return baseSpeed * _speedFactor;
        }

        /// <summary>
        /// Создать экземпляр импульсного двигателя.
        /// </summary>
        public PulseEngine() { }
    }
}
