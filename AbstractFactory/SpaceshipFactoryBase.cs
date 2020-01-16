using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Класс описывающий Абстрактную фабрику.
    /// </summary>
    /// <remarks>
    /// Описываются семейства взаимосвязанных классов для создания космического корабля.
    /// </remarks>
    public abstract class SpaceshipFactoryBase
    {
        /// <summary>
        /// Запас здоровья космического корабля.
        /// </summary>
        public int Health { get; protected set; } = 300;

        /// <summary>
        /// Тип космического корабля.
        /// </summary>
        public string Type { get; protected set; } = "Космический корабль";

        /// <summary>
        /// Создать двигатель космического корабля.
        /// </summary>
        /// <returns>Двигатель.</returns>
        public abstract EngineBase CreateEngine();

        /// <summary>
        /// Создать оружие космического корабля.
        /// </summary>
        /// <returns>Оружие.</returns>
        public abstract GunBase CreateGun();

        /// <summary>
        /// Создать источник энергии космического корабля.
        /// </summary>
        /// <returns>Источник энергии.</returns>
        public abstract EnergyBase CreateEnergy();
    }
}
