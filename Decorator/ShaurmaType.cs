using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Тип шаурмы.
    /// </summary>
    public enum ShaurmaType : int
    {
        /// <summary>
        /// В обычном лаваше.
        /// </summary>
        [Description("Шаурма в обычном лаваше")]
        Standard = 1,

        /// <summary>
        /// В сырном лаваше
        /// </summary>
        [Description("Шаурма в сырном лаваше")]
        Cheese = 2,

        /// <summary>
        /// В арабском лаваше.
        /// </summary>
        [Description("Шаурма в арабском лаваше")]
        Arabic = 3
    }
}
