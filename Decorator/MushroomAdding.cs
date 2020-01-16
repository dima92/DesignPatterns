using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Грибная добавка в шаурму.
    /// </summary>
    public class MushroomAdding : ShaurmaAdding
    {
        /// <summary>
        /// Создать новый экземпляр шаурмы с добавлением грибов.
        /// </summary>
        /// <param name="shaurma">Шаурма, в которую будут добавлены грибы.</param>
        public MushroomAdding(Shaurma shaurma) : base(shaurma)
        {
            Price += 10;
            Name += " с грибами";
        }
    }
}
