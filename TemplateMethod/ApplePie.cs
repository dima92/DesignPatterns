using System;

namespace TemplateMethod
{
    public class ApplePie : PieBase
    {
        /// <inheritdoc />
        protected override void CreateDough()
        {
            Console.WriteLine("Используем слоеное тесто.");
        }

        /// <inheritdoc />
        protected override void CreateFilling()
        {
            Console.WriteLine("Используем яблочную начинку.");
        }

        /// <inheritdoc />
        protected override void Fry()
        {
            Console.WriteLine("Запекаем в духовке при температуре 180 градусов в течении 30 минут.");
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Тип пирога. </returns>
        public override string ToString()
        {
            return "Яблочный пирог";
        }
    }
}