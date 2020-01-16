using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Пиратский космический корабль.
    /// </summary>
    public class PiratSpaceshipFactory : SpaceshipFactoryBase
    {
        /// <summary>
        /// Создать экземпляр пиратского космического корабля.
        /// </summary>
        public PiratSpaceshipFactory()
        {
            Health = 200;
            Type = "Пиратский корабль";
        }

        /// <summary>
        /// Создаем источник энергии пиратского комического корабля.
        /// </summary>
        /// <returns>Плазменный источник энергии.</returns>
        public override EnergyBase CreateEnergy()
        {
            return new PlasmEnergy();
        }

        /// <summary>
        /// Создаем оружие пиратского комического корабля.
        /// </summary>
        /// <returns>Фононная пушка.</returns>
        public override GunBase CreateGun()
        {
            return new PhotonGun();
        }

        /// <summary>
        /// Создаем двигатель пиратского космического корабля.
        /// </summary>
        /// <returns>Фотонный двигатель.</returns>
        public override EngineBase CreateEngine()
        {
            return new PhotonEngine();
        }
    }
}
