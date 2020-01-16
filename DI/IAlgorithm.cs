using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    /// <summary>
    /// Базовый интерфейс криптоалгорима хеш-функции.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// Вычисление нового хеша.
        /// </summary>
        /// <returns>Успешность нахождения хеша.</returns>
        bool Hash();
    }
}
