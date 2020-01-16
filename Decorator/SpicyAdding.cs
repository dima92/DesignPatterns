﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Острая добавка.
    /// </summary>
    public class SpicyAdding : ShaurmaAdding
    {
        /// <summary>
        /// Создать новый экземпляр шаурмы с острой добавкой.
        /// </summary>
        /// <param name="shaurma">Шаурма, в которую добавляется добавка.</param>
        public SpicyAdding(Shaurma shaurma) : base(shaurma)
        {
            Price += 5;
            Name += " острая";
        }
    }
}
