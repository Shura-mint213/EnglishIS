using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static.Enum
{
    /// <summary>
    /// Уровни английского языка
    /// </summary>
    public enum EnglishLevel : byte
    {
        /// <summary>
        /// Начальный
        /// </summary>
        A1 = 1,
        /// <summary>
        /// Ниже среднего
        /// </summary>
        A2 = 2,
        /// <summary>
        /// Средний
        /// </summary>
        B1 = 3,
        /// <summary>
        /// Выше среднего
        /// </summary>
        B2 = 4,
        /// <summary>
        /// Продвинутый
        /// </summary>
        C1 = 5,
        /// <summary>
        /// Профессиональный уровень владения
        /// </summary>
        C2 = 6,
    }
}
