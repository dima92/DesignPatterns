using System;

namespace Memento
{
    /// <summary>
	/// Класс-контроллер отвечающий за проведение боев между космическими кораблями.
	/// </summary>
	public class Battle
    {
        /// <summary>
        /// Первый космический корабль.
        /// </summary>
        private Spaceship _ship1;

        /// <summary>
        /// Второй космический корабль.
        /// </summary>
        private Spaceship _ship2;

        /// <summary>
        /// Создать экземпляр битвы.
        /// </summary>
        /// <param name="ship1"> Первый космический корабль. </param>
        /// <param name="ship2"> Второй космический корабль. </param>
        public Battle(Spaceship ship1, Spaceship ship2)
        {
            _ship1 = ship1 ??
                throw new ArgumentNullException("Первый космический корабль не может быть пустым.", nameof(ship1));

            _ship2 = ship2 ??
                throw new ArgumentNullException("Второй космический корабль не может быть пустым.", nameof(ship2));
        }

        /// <summary>
        /// Бой между космическими кораблями.
        /// </summary>
        /// <returns> Победивший в бою корабль. null - если оба корабля погибли. </returns>
        public Spaceship Fight()
        {
            // Сражаемся насмерть, пока у одного из космических кораблей не закончится здоровье.
            while (_ship1.Health > 0 && _ship2.Health > 0)
            {
                _ship2.TakeDamage(_ship1.Shoot());
                _ship1.TakeDamage(_ship2.Shoot());
            }

            // Выявляем победителя 
            if (_ship1.Health > 0)
            {
                return _ship1;
            }

            if (_ship2.Health > 0)
            {
                return _ship2;
            }

            return null;
        }
    }
}