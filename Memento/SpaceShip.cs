using System;

namespace Memento
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
        /// Запас здоровья космического корабля.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Случайное значение.
        /// </summary>
        public int RandomValue { get; private set; }


        /// <summary>
        /// Создать экземпляр космического корабля.
        /// </summary>
        /// <param name="name"> Название корабля. </param>
        /// <param name="health"> Уровень здоровья корабля. </param>
        public Spaceship(string name, int health = 100)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (health <= 0)
            {
                throw new ArgumentException("Здоровье космического корабля не может быть меньше либо равно нулю.", nameof(health));
            }

            // Устанавливаем свойства.
            Name = name;
            Health = health;
            var rnd = new Random();
            RandomValue = rnd.Next();
        }

        /// <summary>
        /// Выстрелить.
        /// </summary>
        /// <returns> Нанесенный урон. </returns>
        public int Shoot()
        {
            // Задаем минимальный и максимальный возможный урон.
            const int MinDamage = 0;
            const int MaxDamage = 10;

            // Вычисляем значение нанесенного урона.
            var rnd = new Random();
            var damage = rnd.Next(MinDamage, MaxDamage);
            return damage;
        }

        /// <summary>
        /// Получить урон.
        /// </summary>
        /// <param name="damage"> Величина полученного урона. </param>
        public void TakeDamage(int damage)
        {
            // Проверяем входные данные на корректность.
            if (damage < 0)
            {
                throw new ArgumentException("Нанесенный урон не может быть меньше нуля", nameof(damage));
            }

            // Изменяем значение здоровья.
            Health -= damage;
        }

        /// <summary>
        /// Сохранить состояние космического корабля.
        /// </summary>
        /// <returns> Состояние корабля. </returns>
        public MementoSpaceship Save()
        {
            // Формируем снимок для сохранения состояние. 
            var memento = new MementoSpaceship(Name, Health);
            return memento;
        }

        /// <summary>
        /// Восстановить состояние космического корабля из снимка.
        /// </summary>
        /// <param name="memento"> Снимок состояния космического корабля. </param>
        public void Restore(MementoSpaceship memento)
        {
            // Проверяем входные данные на корректность.
            if (memento == null)
            {
                throw new ArgumentNullException(nameof(memento));
            }

            if (string.IsNullOrEmpty(memento.SpaceshipName))
            {
                throw new ArgumentNullException(nameof(memento.SpaceshipName));
            }

            if (memento.Health <= 0)
            {
                throw new ArgumentException("Здоровье космического корабля не может быть меньше либо равно нулю.", nameof(memento.Health));
            }

            // Восстанавливаем состояние из снимка.
            Name = memento.SpaceshipName;
            Health = memento.Health;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Название космического корабля. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}