using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignCashMachine
{
    /// <summary>
    /// Иностранный товар.
    /// </summary>
    public class ForeignProduct
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Создание нового экземпляра класса ForeignProduct.
        /// </summary>
        /// <param name="name"> Название. </param>
        /// <param name="price"> Стоимость. </param>
        public ForeignProduct(string name, double price)
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
        /// <returns> Название. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
