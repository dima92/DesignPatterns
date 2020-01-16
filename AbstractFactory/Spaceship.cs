using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Космический корабль.
    /// </summary>
    public class Spaceship
    {
        /// <summary>
        /// Название космического корабля.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Тип космического корабля.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Запас здоровья космического корабля.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Источник энергии космического корабля.
        /// </summary>
        private EnergyBase _energy;

        /// <summary>
        /// Оружие космического корабля.
        /// </summary>
        private GunBase _gun;

        /// <summary>
        /// Двигатель космического корабля.
        /// </summary>
        private EngineBase _engine;

        /// <summary>
        /// Создать экземпляр космического корабля.
        /// </summary>
        /// <param name="name">Название корабля.</param>
        /// <param name="factory">Фабрика, создающая космический корабль.</param>
        public Spaceship(string name, SpaceshipFactoryBase factory)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }


            Name = name;
            Type = factory.Type;
            Health = factory.Health;
            _energy = factory.CreateEnergy();
            _gun = factory.CreateGun();
            _engine = factory.CreateEngine();
        }

        /// <summary>
        /// Выстрелить.
        /// </summary>
        /// <returns>Нанесенный урон.</returns>
        public int Shoot()
        {
            return _gun.Shoot();
        }

        /// <summary>
        /// Лететь.
        /// </summary>
        /// <returns>Преодоленное расстояние.</returns>
        public int Move()
        {
            return _engine.Move(_energy);
        }

        /// <summary>
        /// Получить урон.
        /// </summary>
        /// <param name="damage">Величина урона.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Полное название космического корабля.</returns>
        public override string ToString()
        {
            return $"{Type} \"{Name}\"";
        }
    }
}
