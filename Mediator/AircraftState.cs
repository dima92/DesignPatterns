using System;
using System.ComponentModel;
using System.Reflection;

namespace Patterns.Mediator
{
    /// <summary>
    /// Состояние самолета.
    /// </summary>
    public enum AircraftState : int
    {
        /// <summary>
        /// Находится в ангаре.
        /// </summary>
        [Description("Находится в ангаре")]
        Sleep = 0,

        /// <summary>
        /// Взлетает.
        /// </summary>
        [Description("Взлетает")]
        GoToFly = 1,

        /// <summary>
        /// Находится в палёте.
        /// </summary>
        [Description("Находится в палёте")]
        Fly = 2,

        /// <summary>
        /// Приземляется.
        /// </summary>
        [Description("Приземляется")]
        GoToLand = 3,

        /// <summary>
        /// Приземлился.
        /// </summary>
        [Description("Приземлился")]
        Land = 4,

        /// <summary>
        /// Разбился.
        /// </summary>
        [Description("Разбился")]
        Dead = 5
    }

    public static class EnumHelper
    {
        /// <summary>
        /// Приведение значения перечисления в удобочитаемый формат.
        /// </summary>
        /// <remarks>
        /// Для корректной работы необходимо использовать атрибут [Description("Name")] для каждого элемента перечисления.
        /// </remarks>
        /// <param name="enumElement">Элемент перечисления</param>
        /// <returns>Название элемента</returns>
        public static string GetDescription(this Enum enumElement)
        {
            Type type = enumElement.GetType();

            MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return enumElement.ToString();
        }
    }
}