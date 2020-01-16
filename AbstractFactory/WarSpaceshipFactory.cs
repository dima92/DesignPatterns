using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Военный космический корабль.
    /// </summary>
    public class WarSpaceshipFactory : SpaceshipFactoryBase
    {
        /// <summary>
        /// Создать экземпляр военного космического корабля.
        /// </summary>
        public WarSpaceshipFactory()
        {
            Health = 500;
            Type = "Военное судно";
        }

        /// <summary>
        /// Создать источник энергии военного космического корабля.
        /// </summary>
        /// <returns>Плазменный двигатель.</returns>
        public override EnergyBase CreateEnergy()
        {
            return new PlasmEnergy();
        }

        /// <summary>
        /// Создать оружие военного космического корабля.
        /// </summary>
        /// <returns>Лазерная пушка.</returns>
        public override GunBase CreateGun()
        {
            return new LaserGun();
        }

        /// <summary>
        /// Создать двигатель военного космического корабля.
        /// </summary>
        /// <returns>Импульсный двигатель.</returns>
        public override EngineBase CreateEngine()
        {
            return new PulseEngine();
        }
    }
}
