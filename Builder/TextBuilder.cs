using System;

namespace TextLib
{
    /// <summary>
    /// Строитель, формирующий оформление текста.
    /// </summary>
    public static class TextBuilder
    {
        /// <summary>
        /// Установить шрифт.
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="font"> Шрифт. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text Font(this Text text, Fonts font)
        {
            // Получаем имя шрифта из перечисления и устанавливаем значение.
            text.Font = Enum.GetName(typeof(Fonts), font);

            // Возвращаем измененный текст.
            return text;
        }

        /// <summary>
        /// Установить размер шрифта.
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="size"> Размер шрифта. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text Size(this Text text, int size)
        {
            // Устанавливаем крайние допустимые значения
            const int MinFontSize = 6;
            const int MaxFontSize = 72;

            if (size <= MinFontSize)
            {
                // Если шрифт меньше либо равен минимальному,
                // то устанавливаем минимальное значение.
                text.Size = MinFontSize;
            }
            else if (size >= MaxFontSize)
            {
                // Если шрифт больше либо равен максимальному,
                // то устанавливаем максимальное значение.
                text.Size = MaxFontSize;
            }
            else
            {
                // Иначе устанавливаем соответствующее значение.
                text.Size = size;
            }

            // Возвращаем измененный текст.
            return text;
        }

        /// <summary>
        /// Установить цвет шрифта. 
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="color"> Цвет шрифта. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text Color(this Text text, ConsoleColor color)
        {
            // Устанавливаем свойства и возвращаем измененный текст.
            text.Color = color;
            return text;
        }

        /// <summary>
        /// Установить цвет заднего фона. 
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="color"> Цвет заднего фона. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text BackgroundColor(this Text text, ConsoleColor color)
        {
            // Устанавливаем свойства и возвращаем измененный текст.
            text.BackgroundColor = color;
            return text;
        }

        /// <summary>
        /// Использовать жирный шрифт. 
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="bold"> true - использовать, false - нет. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text Bold(this Text text, bool bold)
        {
            // Устанавливаем свойства и возвращаем измененный текст.
            text.Bold = bold;
            return text;
        }

        /// <summary>
        /// Использовать наклонный шрифт.
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="italic"> true - использовать, false - нет. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text Italic(this Text text, bool italic)
        {
            // Устанавливаем свойства и возвращаем измененный текст.
            text.Italic = italic;
            return text;
        }

        /// <summary>
        /// Использовать подчеркнутый шрифт. 
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="underline"> true - использовать, false - нет. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text Underline(this Text text, bool underline)
        {
            // Устанавливаем свойства и возвращаем измененный текст.
            text.Underline = underline;
            return text;
        }

        /// <summary>
        /// Задать уровень заголовка.
        /// </summary>
        /// <param name="text"> Форматируемый текст. </param>
        /// <param name="headerLevel"> 0 - обычный текст, 1-6 - заголовки. </param>
        /// <returns> Отформатированный текст. </returns>
        public static Text HeaderLevel(this Text text, int headerLevel)
        {
            // Задаем крайние корректные значения.
            const int NormalText = 0;
            const int MinHeader = 6;

            if (headerLevel <= NormalText)
            {
                // Если задано значение меньше или равное нуля используем обычный текст.
                text.HeaderLevel = NormalText;
            }
            else if (headerLevel >= MinHeader)
            {
                // Если задано значение большее либо равное шести используем заголовок H6.
                text.HeaderLevel = MinHeader;
            }
            else
            {
                // Иначе устанавливаем соответствующий уровень заголовка.
                text.HeaderLevel = headerLevel;
            }

            // Возвращаем измененный текст.
            return text;
        }
    }
}