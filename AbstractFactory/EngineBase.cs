using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Базовый абстрактный класс, описывающий возможности двигателей космических кораблей.
    /// </summary>
    public abstract class EngineBase
    {
        /// <summary>
        /// Количество используемой энергии.
        /// </summary>
        public int UsingEnergy { get; protected set; } = 1;

        /// <summary>
        /// Выполнить полет.
        /// </summary>
        /// <param name="energy">Используемый для полета источник энергии.</param>
        /// <returns>Расстояние, на которое выполнился перелет.</returns>
        public virtual int Move(EnergyBase energy)
        {
            if (energy == null)
            {
                throw new ArgumentNullException(nameof(energy));
            }

            energy.Using(UsingEnergy);
            return 1;
        }
    }
}
