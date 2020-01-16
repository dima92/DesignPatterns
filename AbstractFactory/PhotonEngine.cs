using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Фотонный двигатель.
    /// </summary>
    public class PhotonEngine : EngineBase
    {
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Максимальный множитель скорости.
        /// </summary>
        private readonly int _maxFactor = 10;
        public override int Move(EnergyBase energy)
        {
            if (energy == null)
            {
                throw new ArgumentNullException(nameof(energy));
            }

            // Очень нестабильный, но потенциально быстрый двигатель.

            // Потребляет случайное количество энергии.
            int factorEnergy = _random.Next(0, _maxFactor);
            energy.Using(UsingEnergy * factorEnergy);

            // Движется со случайной скоростью или вообще останавливается.
            int factorSpeed = _random.Next(0, _maxFactor);
            return UsingEnergy * factorSpeed;
        }

        /// <summary>
        /// Создать экземпляр фотонного двигателя.
        /// </summary>
        public PhotonEngine()
        {
            UsingEnergy = 3;
        }
    }
}
