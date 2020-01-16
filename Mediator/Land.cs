using System;

namespace Patterns.Mediator
{
    /// <summary>
    /// Взлетно-посадочная полоса.
    /// </summary>
    public class Land
    {
        /// <summary>
        /// Состояние полосы.
        /// </summary>
        private bool _free;

        /// <summary>
        /// Номер полосы.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Является ли полоса свободной.
        /// </summary>
        public bool Free
        {
            get
            {
                return _free;
            }
            set
            {
                _free = value;
                StateChanged?.Invoke(this, value);
            }
        }

        /// <summary>
        /// Событие изменения состояния занятости полосы.
        /// </summary>
        public event EventHandler<bool> StateChanged;

        /// <summary>
        /// Создать экземпляр взлетно-посадочной полосы.
        /// </summary>
        /// <param name="number">Номер полосы</param>
        public Land(int number)
        {
            Number = number;
            Free = true;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Номер полосы.</returns>
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}