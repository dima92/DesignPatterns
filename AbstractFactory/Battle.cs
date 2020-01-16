using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
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
        /// <param name="ship1">Первый космический корабль.</param>
        /// <param name="ship2">Второй космический корабль.</param>
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
        /// <returns>Победивший в бою корабль. null - если оба корабля погибли.</returns>
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

        /// <summary>
        /// Гонка между космическими кораблями.
        /// </summary>
        /// <returns>Победивший в гонке космический корабль. 
        /// null - если оба пролетели одинаковое расстояние.
        /// </returns>
        public Spaceship Race()
        {
            // Переменные для подсчета дистанции пройденной кораблями.
            int length1 = 0;
            int length2 = 0;

            // Оба корабля летят на протяжении 100 ходов.
            for (int i = 0; i < 100; i++)
            {
                length1 += _ship1.Move();
                length2 += _ship2.Move();
            }

            // Выявляем победителя.
            if (length1 > length2)
            {
                return _ship1;
            }

            if (length2 > length1)
            {
                return _ship2;
            }

            return null;
        }
    }
}
