namespace Strategy
{
    /// <summary>
    /// Интерфейс стратегии.
    /// </summary>
    public interface IConsoleWriter
    {
        /// <summary>
        /// Вывод текста на консоль.
        /// </summary>
        /// <param name="text"> Выводимый текст. </param>
        void WriteText(string text);
    }
}