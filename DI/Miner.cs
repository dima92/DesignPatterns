using DI;
using System;
using System.Threading;

namespace DependencyInjection
{
    /// <summary>
    /// Основной класс выполняющих майнинг.
    /// </summary>
    public class Miner
    {
        /// <summary>
        /// Поток в котором выполняется поиск.
        /// </summary>
        private Thread thread;

        /// <summary>
        /// Событие нахождения хеша.
        /// </summary>
        public event EventHandler<bool> HashFound;

        /// <summary>
        /// Создать экземпляр майнера.
        /// </summary>
        public Miner()
        {

        }

        /// <summary>
        /// Начать майнинг.
        /// </summary>
        public void Start(IAlgorithm algorithm)
        {
            thread = new Thread(() => Mine(algorithm));
            thread.Start();
        }

        /// <summary>
        /// Остановить майнинг.
        /// </summary>
        public void Stop()
        {
            thread.Abort();
        }

        /// <summary>
        /// Метод выполняющий майнинг.
        /// </summary>
        private void Mine(IAlgorithm algorithm)
        {
            while (true)
            {
                var hashResult = algorithm.Hash();
                HashFound?.Invoke(this, hashResult);
            }
        }
    }
}