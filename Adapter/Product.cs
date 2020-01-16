using System;

namespace Adapter
{
    /// <summary>
    /// Товар.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Наименование товара.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Создать новый экземпляр товара.
        /// </summary>
        /// <param name="name">Название.</param>
        /// <param name="price">Цена.</param>
        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (price < 0)
            {
                throw new ArgumentException("Цена не может быть меньше нуля.", nameof(price));
            }

            Name = name;
            Price = price;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Название товара.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}