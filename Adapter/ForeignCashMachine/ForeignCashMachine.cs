using System;
using System.Collections.Generic;
using System.Linq;

namespace ForeignCashMachine
{
    /// <summary>
    /// Иностранный кассовый аппарат.
    /// </summary>
    public class ForeignCashMachine
    {
        /// <summary>
        /// Список чеков, хранящихся в кассовом аппарате.
        /// </summary>
        private List<Check> _checks = new List<Check>();

        /// <summary>
        /// Название кассового аппарата.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Массив чеков, хранящихся в кассовом аппарате.
        /// </summary>
        public Check[] Checks => _checks.ToArray();

        /// <summary>
        /// Текущий заполняемый чек.
        /// </summary>
        public Check CurrentCheck => _checks.LastOrDefault();

        /// <summary>
        /// Создать экземпляр кассового аппарата.
        /// </summary>
        public ForeignCashMachine()
        {
            var rnd = new Random();
            Name = $"KKA{rnd.Next(10000, 99999)}";
            _checks.Add(new Check());
        }

        /// <summary>
        /// Добавить товар в текущий чек.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="price">Стоимость товара.</param>
        public void Add(string name, double price)
        {
            CurrentCheck.Add(name, price);
        }

        /// <summary>
        /// Сохранить чек.
        /// </summary>
        /// <remarks>
        /// Возвращается копия последнего заполненного кассового чека,
        /// а в кассовом аппарате заводится новый пустой чек.
        /// </remarks>
        /// <returns>Чек.</returns>
        public Check Save()
        {
            var check = (Check)CurrentCheck.Clone();
            _checks.Add(new Check());
            return check;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Название кассового аппарата.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}