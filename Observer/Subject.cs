using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// Наблюдаемый класс.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Название наблюдаемого.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Событие, генерируемое при сохранении сущности.
        /// </summary>
        public event EventHandler OnSaved;

        /// <summary>
        /// Создать экземпляр наблюдаемого класса.
        /// </summary>
        /// <param name="name">Имя наблюдаемого.</param>
        public Subject(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Сохранить наблюдаемый класс.
        /// </summary>
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter("temp.txt", false, Encoding.Default))
            {
                sw.WriteLine(Name);
            }

            // Такая форма записи используется для того, чтобы избежать исключения NullReferenceException,
            // если нет ни одного подписчика у события.
            OnSaved?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
