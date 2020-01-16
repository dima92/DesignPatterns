using System;
using System.Collections.Generic;
using System.Linq;

namespace ForeignCashMachine
{
    /// <summary>
    /// Кассовый чек.
    /// </summary>
    public class Check : ICloneable
    {
        /// <summary>
        /// Список товаров в кассовом чеке.
        /// </summary>
        private List<(string Name, double Price)> _products;

        /// <summary>
        /// Номер чека.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Дата создания чека.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Товары в чеке.
        /// </summary>
        public IEnumerable<(string Name, double Price)> Products => _products;

        /// <summary>
        /// Создать экземпляр чека.
        /// </summary>
        public Check()
        {
            var rnd = new Random();

            Number = rnd.Next(10000, 99999);
            DateTime = DateTime.Now;
            _products = new List<(string Name, double Price)>();
        }

        /// <summary>
        /// Добавить товар в чек.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public void Add(string name, double price)
        {
            _products.Add((name, price));
        }

        /// <summary>
        /// Создать копию чека.
        /// </summary>
        /// <returns>Копия чека.</returns>
        public object Clone()
        {
            return new Check()
            {
                _products = _products,
                DateTime = DateTime,
                Number = Number
            };
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Текст чека.</returns>
        public override string ToString()
        {
            var checkText = $"Кассовый чек от {DateTime.ToString("HH:mm dd.MMMM.yyyy")}\r\n";
            checkText += $"Номер чека: {Number}\r\n";
            return checkText;
        }
    }
}