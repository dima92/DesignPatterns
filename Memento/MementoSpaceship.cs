using System;

namespace Memento
{
    /// <summary>
    /// Снимок состояния космического корабля.
    /// </summary>
    public class MementoSpaceship : ICloneable
    {
        /// <summary>
        /// Дата и время создания снимка.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Название космического корабля.
        /// </summary>
        public string SpaceshipName { get; private set; }

        /// <summary>
        /// Здоровье космического корабля.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Создать новый экземпляр снимка космического корабля.
        /// </summary>
        /// <param name="spaceshipName"> Название. </param>
        /// <param name="health"> Состояние здоровья. </param>
        public MementoSpaceship(string spaceshipName, int health)
        {
            // Проверяем входные параметры на корректность.
            if (string.IsNullOrEmpty(spaceshipName))
            {
                throw new ArgumentNullException(nameof(spaceshipName));
            }

            if (health <= 0)
            {
                throw new ArgumentException("Здоровье космического корабля не может быть меньше или равным нулю.", nameof(health));
            }

            // Устанавливаем значения.
            SpaceshipName = spaceshipName;
            Health = health;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Создать копию объекта.
        /// </summary>
        /// <returns> Копия объекта. </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Дата и время создания снимка. </returns>
        public override string ToString()
        {
            return CreatedAt.ToString();
        }


    }
}