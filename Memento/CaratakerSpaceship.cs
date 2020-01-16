using System;
using System.Collections.Generic;
using System.Linq;

namespace Memento
{
    /// <summary>
    /// Хранилище состояний космического корабля.
    /// </summary>
    public class CaratakerSpaceship
    {
        /// <summary>
        /// Коллекция всех снимков состояния космического корабля.
        /// </summary>
        private List<MementoSpaceship> _mementos = new List<MementoSpaceship>();

        /// <summary>
        /// Сохранения состояний космического корабля.
        /// </summary>
        public IReadOnlyList<MementoSpaceship> Mementos => _mementos;

        /// <summary>
        /// Создать новый экземпляр хранилища состояний космического корабля.
        /// </summary>
        public CaratakerSpaceship() { }

        /// <summary>
        /// Сохранить снимок в хранилище.
        /// </summary>
        /// <param name="memento"> Снимок состояние космического корабля. </param>
        public void Save(MementoSpaceship memento)
        {
            // Проверяем входные данные на корректность.
            if (memento == null)
            {
                throw new ArgumentNullException(nameof(memento));
            }

            // Добавляем состояние в коллекцию.
            _mementos.Add(memento);
        }

        /// <summary>
        /// Получить последний снимок состояния космического корабля.
        /// </summary>
        /// <returns> Снимок состояния космического корабля. </returns>
        public MementoSpaceship Restore()
        {
            if (_mementos.Count == 0)
            {
                throw new IndexOutOfRangeException("Не возможно восстановить состояние из коллекции. Коллекция пуста.");
            }

            var result = _mementos.LastOrDefault() ??
                throw new IndexOutOfRangeException("Не возможно восстановить состояние из коллекции. Не удалось получить состояние.");

            return result.Clone() as MementoSpaceship;
        }
    }
}