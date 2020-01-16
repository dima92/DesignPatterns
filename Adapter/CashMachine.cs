using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    /// <summary>
    /// Кассовый аппарат собственного производства.
    /// </summary>
    public class CashMachine : ICashMachine
    {
        /// <summary>
        /// Список товаров в чеке.
        /// </summary>
        private List<Product> _products;

        /// <summary>
        /// Уникальный номер кассового аппарата.
        /// </summary>
        private Guid _number;

        /// <inheritdoc />
        public IReadOnlyList<Product> Products => _products;

        /// <inheritdoc />
        public string Number => _number.ToString();

        /// <summary>
        /// Создать новый экземпляр кассового аппарата.
        /// </summary>
        public CashMachine()
        {
            _number = Guid.NewGuid();
            _products = new List<Product>();
        }

        /// <inheritdoc />
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _products.Add(product);
        }

        /// <inheritdoc />
        public string PrintCheck()
        {
            var checkText = GetCheckText();
            Save(checkText);
            return checkText;
        }

        /// <inheritdoc />
        public void Save(string checkText)
        {
            if (string.IsNullOrEmpty(checkText))
            {
                throw new ArgumentNullException(nameof(checkText));
            }

            using (var sr = new StreamWriter("checks.txt", true, Encoding.Default))
            {
                sr.WriteLine(checkText);
            }
            _products.Clear();
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Номер кассового аппарата.</returns>
        public override string ToString()
        {
            return $"Касса №{Number}";
        }

        /// <summary>
        /// Сформировать текст чека для вывода на печать и сохранения в файл.
        /// </summary>
        /// <returns>Форматированный текст чека.</returns>
        private string GetCheckText()
        {
            var date = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            var checkText = $"Кассовый чек от {date}\r\n";
            checkText += $"Идентификатор чека: {Guid.NewGuid()}\r\n";
            checkText += "Список товаров:\r\n";
            foreach (var product in _products)
            {
                checkText += $"{product.Name}\t\t\t{product.Price}\r\n";
            }
            var sum = _products.Sum(p => p.Price);
            checkText += $"ИТОГО\t\t\t{sum}\r\n";
            return checkText;
        }
    }
}
