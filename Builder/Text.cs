using System;

namespace TextLib
{
    /// <summary>
    /// Форматированный HTML текст.
    /// </summary>
    public class Text
    {
        /// <summary>
        /// Цвет шрифта.
        /// </summary>
        public ConsoleColor Color { get; internal set; } = ConsoleColor.White;

        /// <summary>
        /// Цвет заднего фона.
        /// </summary>
        public ConsoleColor BackgroundColor { get; internal set; } = ConsoleColor.Black;

        /// <summary>
        /// Жирный шрифт.
        /// </summary>
        public bool Bold { get; internal set; } = false;

        /// <summary>
        /// Наклонный шрифт.
        /// </summary>
        public bool Italic { get; internal set; } = false;

        /// <summary>
        /// Подчеркнутый шрифт.
        /// </summary>
        public bool Underline { get; internal set; } = false;

        /// <summary>
        /// Текст.
        /// </summary>
        public string Content { get; internal set; } = "";

        /// <summary>
        /// Уровень заголовка.
        /// </summary>
        public int HeaderLevel { get; internal set; } = 0;

        /// <summary>
        /// Шрифт.
        /// </summary>
        public string Font { get; internal set; } = "Arial";

        /// <summary>
        /// Размер шрифта.
        /// </summary>
        public int Size { get; internal set; } = 12;

        /// <summary>
        /// Создать новый экземпляр класса текст.
        /// </summary>
        /// <param name="content"> Текст. </param>
        public Text(string content)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            // Устанавливаем значение.
            Content = content;
        }

        /// <summary>
        /// Напечатать текст.
        /// </summary>
        /// <returns> Текст с разметкой HTML. </returns>
        public string Print()
        {
            // Если уровень заголовка равен нулю, 
            // то используем тег обычного текста P,
            // иначе используем тег H1, H2, ... , H6, в зависимости от значения.
            var mainTag = HeaderLevel == 0 ? "P" : $"H{HeaderLevel}";

            // Форматируем теги в соответствии со свойствами.
            var formatedContent = $"<{mainTag} style=\"background-color: {BackgroundColor}; \">" +
                $"<FONT size=\"{Size}\" color=\"{Color}\" face=\"{Font}\">" +
                (Bold == true ? "<STRONG>" : "") +
                (Italic == true ? "<EM>" : "") +
                (Underline == true ? "<U>" : "") +
                Content +
                (Underline == true ? "</U>" : "") +
                (Italic == true ? "</EM>" : "") +
                (Bold == true ? "</STRONG>" : "") +
                $"</FONT></{mainTag}>";

            // Возвращаем форматированный текст.
            return formatedContent;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Хранимый текст. </returns>
        public override string ToString()
        {
            return Content;
        }
    }
}