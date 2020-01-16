using System;

namespace Prototype
{
    /// <summary>
    /// Клонируемый объект с текстом.
    /// </summary>
    public class TextCloneable : ICloneable
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
        /// Создать новый экземпляр клонируемого текста.
        /// </summary>
        /// <param name="content"> Текстовые данные. </param>
        public TextCloneable(string content)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            // Устанавливаем значения.
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

        /// <summary>
        /// Клонировать объект.
        /// </summary>
        /// <returns> Дубликат объекта. </returns>
        public object Clone()
        {
            // Поверхностное копирование.
            // return MemberwiseClone();

            // Глубокое копирование.
            var newContent = Content.Clone().ToString();
            var newText = new TextCloneable(newContent);
            return newText;
        }
    }
}