using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    /// <summary>
    /// Интерфейс кассового аппарата.
    /// </summary>
    public interface ICashMachine
    {
        /// <summary>
        /// Уникальный номер кассового аппарата.
        /// </summary>
        string Number { get; }

        /// <summary>
        /// Коллекция товаров в текущем чеке.
        /// </summary>
        IReadOnlyList<Product> Products { get; }

        /// <summary>
        /// Собрать чек и вывести его на печать.
        /// </summary>
        /// <remarks>
        /// Печать чека вызывает его сохранение и очистку коллекции товаров текущего чека.
        /// </remarks>
        /// <returns>Текст чека</returns>
        string PrintCheck();

        /// <summary>
        /// Добавить товар в коллекцию товаров текущего чека.
        /// </summary>
        /// <param name="product">Товар, добавляемый в чек.</param>
        void AddProduct(Product product);

        /// <summary>
        /// Сохранить чек.
        /// </summary>
        /// <remarks>
        /// Сохранение чека вызывает очистку коллекции товаров текущего чека.
        /// </remarks>
        /// <param name="checkText"></param>
        void Save(string checkText);
    }
}
