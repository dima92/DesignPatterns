using ForeignCashMachine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Adapter
{
    /// <summary>
    /// Адаптер для работы с иностранными кассовыми аппаратами как с обычными.
    /// </summary>
    public class ForeignCashMachineAdapter : ICashMachine
    {
        /// <summary>
        /// Иностранный кассовый аппарат.
        /// </summary>
        private ForeignCashMachine.ForeignCashMachine _foreignCashMachine;

        /// <inheritdoc />
        public string Number => _foreignCashMachine.Name;

        /// <inheritdoc />
        public IReadOnlyList<Product> Products
        {
            get
            {
                var productsTuple = _foreignCashMachine.CurrentCheck.Products;
                var products = productsTuple.Select(s => new Product(s.Name, Convert.ToDecimal(s.Price)));
                return (IReadOnlyList<Product>)products;
            }
        }

        /// <summary>
        /// Создать экземпляр иностранного кассового аппарата под обычный.
        /// </summary>
        /// <param name="foreignCashMachine">Иностранный кассовый аппарат.</param>
        public ForeignCashMachineAdapter(ForeignCashMachine.ForeignCashMachine foreignCashMachine)
        {
            _foreignCashMachine = foreignCashMachine
                ?? throw new ArgumentNullException(nameof(foreignCashMachine));
        }

        /// <inheritdoc />
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _foreignCashMachine.Add(product.Name, Convert.ToDouble(product.Price));
        }

        /// <inheritdoc />
        public string PrintCheck()
        {
            var check = _foreignCashMachine.Save();
            var checkText = GetCheckText(check);
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

            using (var sr = new StreamWriter("checks2.txt", true, Encoding.Default))
            {
                sr.WriteLine(checkText);
            }
        }

        /// <summary>
        /// Сформировать текст чека для вывода на печать и сохранения в файл.
        /// </summary>
        /// <param name="check">Чек иностранного кассового аппарата.</param>
        /// <returns>Форматированный текст чека.</returns>
        private string GetCheckText(ForeignCashMachine.Check check)
        {
            var date = check.DateTime.ToString("dd MMMM yyyy HH:mm");
            var checkText = $"Кассовый чек от {date}\r\n";
            checkText += $"Идентификатор чека: {check.Number}\r\n";
            checkText += "Список товаров:\r\n";
            foreach (var product in check.Products)
            {
                checkText += $"{product.Name}\t\t\t{product.Price}\r\n";
            }
            var sum = check.Products.Sum(p => p.Price);
            checkText += $"ИТОГО\t\t\t{sum}\r\n";
            return checkText;
        }
    }
}