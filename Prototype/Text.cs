using System;

namespace Prototype
{
    /// <summary>
    /// Обычный класс с текстом.
    /// </summary>
    public class Text
    {
        /// <summary>
        /// Количество символов на странице.
        /// </summary>
        private readonly int _symbolsOnPage = 100;

        /// <summary>
        /// Хранимые текстовые данные.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Количество страниц текста.
        /// </summary>
        public int Pages
        {
            get
            {
                if (Content != null)
                {
                    return Content.Length / _symbolsOnPage + 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Создать новый экземпляр обычного текста.
        /// </summary>
        /// <param name="content"> Текстовые данные. </param>
        public Text(string content)
        {
            // Проверяем выходные данные на корректность.
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            // Устанавливаем значение.
            Content = content;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Хранимые текстовые данные. </returns>
        public override string ToString()
        {
            return Content;
        }
    }
}