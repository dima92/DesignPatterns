using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// Класс, реализующий паттерн Одиночка.
    /// </summary>
    /// <remarks>
    /// Порождающий паттерн, гарантирующий, что для класса будет создан только один единственный экземпляр.
    /// </remarks>
    public class Singleton
    {
        /// <summary>
        /// Объект синхронизации, необходим для безопасности при многопоточном использовании.
        /// </summary>
        private static object _sync = new object();

        /// <summary>
        /// Основной объект, в котором будет храниться уникальный экземпляр класса. 
        /// </summary>
        private static volatile Singleton _instance;

        /// <summary>
        /// Какие-либо хранимые данные.
        /// </summary>
        private string _data;

        /// <summary>
        /// Данные, используемые в классе.
        /// </summary>
        public string Data => _data;

        /// <summary>
        /// Защищенный конструктор для инициализации единственного экземпляра класса.
        /// </summary>
        /// <param name="data">Данные, используемые в классе.</param>
        private Singleton(string data)
        {
            _data = data;
        }

        /// <summary>
        /// Получить экземпляр класса.
        /// </summary>
        /// <param name="data">Инициализирующие данные класса.</param>
        /// <returns>Уникальный экземпляр класса.</returns>
        public static Singleton GetInstance(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Если экземпляр еще не инициализирован - выполняем инициализацию. 
            // Иначе возвращаем имеющийся экземпляр.
            if (_instance == null)
            {
                lock (_sync) // Используется чтобы избежать одновременного доступа критической секции из разных потоков.
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton(data);
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Данные класса в строковом формате.</returns>
        public override string ToString()
        {
            return Data;
        }
    }
}
