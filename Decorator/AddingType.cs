using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Добавка к шаурме.
    /// </summary>
    public enum AddingType : int
    {
        /// <summary>
        /// Без добавок.
        /// </summary>
        [Description("Без добавок")]
        None = 0,

        /// <summary>
        /// Сыр.
        /// </summary>
        [Description("Сыр")]
        Cheese = 1,

        /// <summary>
        /// Имбирь.
        /// </summary>
        [Description("Имбирь")]
        Ginger = 2,

        /// <summary>
        /// Грибы.
        /// </summary>
        [Description("Грибы")]
        Mushroom = 3,

        /// <summary>
        /// Острая.
        /// </summary>
        [Description("Острая")]
        Spisy = 4
    }
}
