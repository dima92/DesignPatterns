using DI;
using System;
using System.Threading;

namespace DependencyInjection
{
    /// <summary>
    /// Алгоритм вычисления хеш-функции SHA254.
    /// </summary>
    public class SHA256 : IAlgorithm
    {
        /// <inheritdoc />
        public bool Hash()
        {
            var guid = Guid.NewGuid();
            Thread.Sleep(5000);
            var hash = guid.GetHashCode();
            if (hash <= 10000)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Имя алгоритма.</returns>
        public override string ToString()
        {
            return nameof(SHA256);
        }
    }
}